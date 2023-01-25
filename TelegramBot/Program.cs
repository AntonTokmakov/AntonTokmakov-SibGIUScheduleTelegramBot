using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new TelegramBotClient("");
            client.StartReceiving(Update, Error);
            Console.ReadLine();
        }

        async private static Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            var message = update.Message;
            if (message.Text != null)
            {
               string textMessage = "";
               DayLessons dayLesson = new DayLessons();
               dayLesson.requestDB(message.Text);                    
                for (int i = 0; i < dayLesson.getCount(); i++)
               {
                    textMessage += String.Format("{0,10}|{1,10}|{2,10}\n", dayLesson.lessons[i], dayLesson.offise[i], dayLesson.teacher[i]);
               }  
                await botClient.SendTextMessageAsync(message.Chat.Id, textMessage);
                return;
            }
        }

        private static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            throw new NotImplementedException();
        }
    }
}
