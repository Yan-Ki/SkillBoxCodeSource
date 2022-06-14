using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Exceptions;

//if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
//{
//    var message = update.Message;
//    switch (message.Text.ToLower())
//    {
//        case "/start":
//            await botClient.SendTextMessageAsync(message.Chat, "Добро пожаловать на борт, добрый путник!");
//            break;
//        case "hi":
//            await botClient.SendTextMessageAsync(message.Chat, "Да пошёл ты!!!");
//            break;
//        default:
//            await botClient.SendTextMessageAsync(message.Chat, "Привет-привет!!");
//            break;
//    }

namespace TestBot
{
    class Program
    {
        static ITelegramBotClient bot = new TelegramBotClient("5512214364:AAGjH5_zeRw0uYRhEGug5Tv87SCD2FnDHG8");
        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            // Некоторые действия
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                var message = update.Message;
                if (message.Text.ToLower() == "/start")
                {
                    await botClient.SendTextMessageAsync(message.Chat, "Добро пожаловать на борт, добрый путник!");
                    return;
                }
                await botClient.SendTextMessageAsync(message.Chat, "Привет-привет!!");
            }
        }

        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            // Некоторые действия
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Запущен бот " + bot.GetMeAsync().Result.FirstName);

            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }, // receive all update types
            };
            bot.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken
            );
            Console.ReadLine();
        }
    }

}