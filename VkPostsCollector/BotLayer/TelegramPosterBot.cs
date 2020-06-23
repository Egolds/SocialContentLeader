using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using VkPostsCollector.ApplicationLayer;
using VkPostsCollector.BusinessLayer;
using VkPostsCollector.DataAccessLayer.API;

namespace VkPostsCollector.BotLayer
{
    public class TelegramPosterBot
    {
        #region -- Свойства / Properties --

        public bool IsExecution { get; set; }

        public TimeSpan PublicateTimeFrom { get; private set; }
        public TimeSpan PublicateTimeTo { get; private set; }

        public TimeSpan CurrentTime
        {
            get => DateTime.Now.TimeOfDay;
        }

        /// <summary>
        /// Кол-во рабочего времени
        /// </summary>
        public TimeSpan WorkHoursQuantity { get; private set; }

        /// <summary>
        /// Оставшееся кол-во рабочего времени
        /// </summary>
        public TimeSpan CurrentWorkHoursQuantity { get; private set; }

        /// <summary>
        /// Кол-во опубликованных постов
        /// </summary>
        public decimal PublicatedTelegramPublicationsCount { get; private set; }

        /// <summary>
        /// Опубликованные посты
        /// </summary>
        public List<TelegramPublicationDTO> PublicatedTelegramPublications = new List<TelegramPublicationDTO>();

        #endregion

        #region -- События / Events --

        public event OnPublicationSendedEvent OnPublicationSended;
        public delegate void OnPublicationSendedEvent(TelegramPublicationDTO telegramPublicationDTO);

        public event OnPublicationCanceledEvent OnPublicationCanceled;
        public delegate void OnPublicationCanceledEvent(TelegramPublicationDTO telegramPublicationDTO);

        public event OnLogWriteEvent OnLogWrite;
        public delegate void OnLogWriteEvent(string LOG);

        #endregion

        #region -- Поля / Fields --

        private List<string> PublicatedVkPostIds = new List<string>();
        private List<string> NotMatchedVkPostIds = new List<string>();

        private Thread ThreadBot { get; set; }

        #endregion

        public TelegramPosterBot(TimeSpan publicateTimeFrom, TimeSpan publicateTimeTo)
        {
            PublicateTimeFrom = publicateTimeFrom;
            PublicateTimeTo = publicateTimeTo;
        }

        public void Start()
        {
            Log("Начинию выполнение");

            IsExecution = true;

            ThreadBot = new Thread(Execution);
            ThreadBot.IsBackground = false;
            ThreadBot.Start();
        }

        public void Stop()
        {
            IsExecution = false;
            ThreadBot.Abort();

            Log("Работа остановлена");
        }

        private void Execution()
        {
            List<VkPublicationDTO> AllVkPublications = new List<VkPublicationDTO>();
            List<VkPublicationDTO> SelectedVkPublications = new List<VkPublicationDTO>();
            List<TelegramPublicationDTO> QueueTelegramPublications = new List<TelegramPublicationDTO>();

            bool WorkDayComplited = false;

            TimeSpan NeedSleepTime = new TimeSpan(0, 0, 0);
            bool NeedSleep = false;

            while (IsExecution)
            {
                #region -- График работы --
                
                if (NeedSleep)
                {
                    Thread.Sleep((int)NeedSleepTime.TotalMilliseconds);
                    NeedSleep = false;
                    WorkDayComplited = false;
                }

                Log("Обработка...");

                bool CanGo = false;
                if (PublicateTimeFrom <= PublicateTimeTo)
                {
                    WorkHoursQuantity = PublicateTimeTo - PublicateTimeFrom;

                    if (CurrentTime >= PublicateTimeFrom && CurrentTime <= PublicateTimeTo)
                    {
                        CanGo = true;
                    }
                }
                else
                {
                    WorkHoursQuantity = new TimeSpan(24, 0, 0) - PublicateTimeFrom + PublicateTimeTo;

                    if (CurrentTime >= PublicateTimeFrom || CurrentTime <= PublicateTimeTo)
                    {
                        CanGo = true;
                    }
                }

                if (CanGo == false && WorkDayComplited == false)
                {
                    if (CurrentTime < PublicateTimeFrom)
                    {
                        NeedSleepTime = PublicateTimeFrom - CurrentTime;
                    }
                    else if (CurrentTime > PublicateTimeTo)
                    {
                        NeedSleepTime = new TimeSpan(24, 0, 0) - CurrentTime + PublicateTimeFrom;
                    }

                    Log($"Ожидаю начало рабочего времени. " +
                        $"Время сейчас: {CurrentTime.ToString("hh\\:mm\\:ss")}, " +
                        $"начало с {PublicateTimeFrom.ToString("hh\\:mm\\:ss")}, " +
                        $"осталось ждать: {NeedSleepTime.ToString("hh\\:mm\\:ss")}");

                    NeedSleep = true;
                    continue;
                    
                    //TODO Запуск отдельного потока для отслеживания команд
                }

                if (WorkDayComplited)
                {
                    if (CurrentTime > PublicateTimeFrom)
                    {
                        NeedSleepTime = new TimeSpan(24, 0, 0) - CurrentTime + PublicateTimeFrom;
                    }
                    else
                    {
                        NeedSleepTime = PublicateTimeFrom - CurrentTime;
                    }

                    Log($"Ожидаю начало рабочего времени. " +
                        $"Время сейчас: {CurrentTime.ToString("hh\\:mm\\:ss")}, " +
                        $"начало с {PublicateTimeFrom.ToString("hh\\:mm\\:ss")}, " +
                        $"осталось ждать: {NeedSleepTime.ToString("hh\\:mm\\:ss")}");

                    NeedSleep = true;
                    continue;

                    //TODO Запуск отдельного потока для отслеживания команд
                }

                #endregion

                #region -- Сбор постов --

                Log("Выполняю сбор постов");

                AllVkPublications.Clear();
                SelectedVkPublications.Clear();

                int LastPostsQuantity = Configs.PublicationFilters.QuantityProcessLastPostsPerGroup;

                for (int i = 0; i < Configs.Groups.Count; i++)
                {
                    int CollectedQuantity = 0;

                    while (CollectedQuantity < LastPostsQuantity)
                    {
                        int CurrentQuantity = LastPostsQuantity - CollectedQuantity;
                        if (CurrentQuantity > 100) CurrentQuantity = 100;

                        List<VkPublicationDTO> publications = VkAPI.GetWallPosts(Configs.Groups[i], CurrentQuantity, CollectedQuantity, Configs.AccessToken);
                        AllVkPublications.AddRange(publications);
                        CollectedQuantity += CurrentQuantity;
                    }
                }

                Log("Сбор постов выполнен");

                #endregion

                Log("Выполняю обработку постов");

                // Сортировка согласно приоритету
                switch (Configs.PublicationFilters.Priority)
                {
                    case PublicationFilters.PriorityEnum.LikesCTR:
                        AllVkPublications = AllVkPublications.OrderByDescending(x => x.LikesCTR).ToList();
                        break;

                    case PublicationFilters.PriorityEnum.Likes:
                        AllVkPublications = AllVkPublications.OrderByDescending(x => x.Likes).ToList();
                        break;

                    case PublicationFilters.PriorityEnum.Comments:
                        AllVkPublications = AllVkPublications.OrderByDescending(x => x.Comments).ToList();
                        break;

                    case PublicationFilters.PriorityEnum.Reposts:
                        AllVkPublications = AllVkPublications.OrderByDescending(x => x.Reposts).ToList();
                        break;
                }

                GoAgain:
                // Отбор с учетом максимального кол-ва постов с одной группы и учет повторяющихся постов
                for (int i = 0; i < AllVkPublications.Count; i++)
                {
                    int GroupReps = SelectedVkPublications.Count(x => x.Group == AllVkPublications[i].Group);

                    if (PublicatedVkPostIds.Contains(AllVkPublications[i].Id) 
                        || NotMatchedVkPostIds.Contains(AllVkPublications[i].Id)
                        || SelectedVkPublications.Contains(AllVkPublications[i]))
                        continue;

                    if (GroupReps < Configs.PublicationFilters.QuantityPostsFromGroup)
                    {
                        SelectedVkPublications.Add(AllVkPublications[i]);
                    }
                }
                
                // Удаление лишниних публикаций согласно их максимальному кол-ву
                if(SelectedVkPublications.Count > Configs.PublicationFilters.MaxQuantityPostsDaily && Configs.PublicationFilters.MaxQuantityPostsDaily > -1)
                {
                    SelectedVkPublications.RemoveRange((int)Configs.PublicationFilters.MaxQuantityPostsDaily, SelectedVkPublications.Count - (int)Configs.PublicationFilters.MaxQuantityPostsDaily);
                }

                // Создание Telegram постов + добавление в очередь
                for (int i = 0; i < SelectedVkPublications.Count; i++)
                {
                    if (QueueTelegramPublications.Exists(x => x.VkPublication.Id == SelectedVkPublications[i].Id))
                        continue;

                    TelegramPublicationDTO telegramPost = PublicationCreator.CreateTelegramPublication(SelectedVkPublications[i]);

                    bool CanPublicate = true;
                    if (telegramPost == null)
                    {
                        Log("Ошибка создания объекта Telegram-публикации");
                        CanPublicate = false;
                    }
                    else if (telegramPost.Error.Length > 0)
                    {
                        Log(telegramPost.Error);
                        NotMatchedVkPostIds.Add(SelectedVkPublications[i].Id);
                        OnPublicationCanceled?.Invoke(telegramPost);
                        CanPublicate = false;
                    }
                    else if (telegramPost.CanPublicate == false)
                    {
                        Log("Публикация отклонена. Не соответствует фильтру");
                        NotMatchedVkPostIds.Add(SelectedVkPublications[i].Id);
                        OnPublicationCanceled?.Invoke(telegramPost);
                        CanPublicate = false;
                    }
                    
                    if (CanPublicate)
                        QueueTelegramPublications.Add(telegramPost);
                }

                // Добавление недостающих постов, если это возможно
                if (QueueTelegramPublications.Count < Configs.PublicationFilters.MinQuantityPostsDaily && Configs.PublicationFilters.MinQuantityPostsDaily > -1)
                {
                    SelectedVkPublications.RemoveAll(x => NotMatchedVkPostIds.Contains(x.Id));

                    goto GoAgain; // Выполнить сбор ещё раз
                }

                DefineCurrentWorkHoursQuantity();
                int TotalWorkMilliseconds = (int)CurrentWorkHoursQuantity.TotalMilliseconds; //(int)WorkHoursQuantity.TotalMilliseconds;
                int BreakTime = TotalWorkMilliseconds / QueueTelegramPublications.Count;

                // Публикация постов в Telegram
                for (int i = 0; i < QueueTelegramPublications.Count; i++)
                {
                    bool ExistsImage = false;
                    if (QueueTelegramPublications[i].PhotoUrl != null && QueueTelegramPublications[i].PhotoUrl != string.Empty)
                        ExistsImage = true;

                    Log($"Начинаю отправку публикации {QueueTelegramPublications[i].VkPublication.Id} Telegram-боту");
                    if (TelegramAPI.SendPublicationAsync(QueueTelegramPublications[i], ExistsImage))
                    {
                        PublicatedTelegramPublications.Add(QueueTelegramPublications[i]);
                        PublicatedVkPostIds.Add(QueueTelegramPublications[i].VkPublication.Id);
                        PublicatedTelegramPublicationsCount++;

                        OnPublicationSended?.Invoke(QueueTelegramPublications[i]);
                        Log($"Публикация {QueueTelegramPublications[i].VkPublication.Id} отпралена Telegram-боту");
                    }
                    else
                    {
                        Log($"Не удалось отправить публикацию {QueueTelegramPublications[i].VkPublication.Id} Telegram-боту");
                    }

                    Log($"Следующая публикация через {TimeSpan.FromMilliseconds(BreakTime).ToString("hh\\:mm\\:ss")}");
                    if (i < QueueTelegramPublications.Count - 1)
                        Thread.Sleep(BreakTime);
                }

                // Очистка очереди
                QueueTelegramPublications.Clear();

                Log("Завершено");
                WorkDayComplited = true;

                Thread.Sleep(3000);
            }
        }

        private void DefineCurrentWorkHoursQuantity()
        {
            if (PublicateTimeFrom <= PublicateTimeTo)
            {
                if(CurrentTime < PublicateTimeFrom)
                {
                    CurrentWorkHoursQuantity = PublicateTimeTo - PublicateTimeFrom;
                }
                else if(CurrentTime > PublicateTimeTo)
                {
                    CurrentWorkHoursQuantity = new TimeSpan(0, 0, 0);
                }
                else
                {
                    CurrentWorkHoursQuantity = PublicateTimeTo - CurrentTime;
                }
            }
            else
            {
                CurrentWorkHoursQuantity = new TimeSpan(24, 0, 0) - CurrentTime + PublicateTimeTo;
            }
        }

        private void Log(string content)
        {
            OnLogWrite?.Invoke(content);
        }
    }
}
