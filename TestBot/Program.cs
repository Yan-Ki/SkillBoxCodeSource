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
        private static string token { get; set; } = "ВСТАВЬТЕ СЮДА СВОЙ ТОКЕН!";
        private static TelegramBotClient Bot;
        static void Main(string[] args)
        {
            Bot = new TelegramBotClient(token);

            //using var cts = new CancellationTokenSource();

            // StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
            //ReceiverOptions receiverOptions = new() { AllowedUpdates = { } };
            //Bot.StartReceiving(Handlers.HandleUpdateAsync,
            //                   Handlers.HandleErrorAsync,
            //                   receiverOptions,
            //                   cts.Token);

            //Console.WriteLine($"Бот запущен и ждет сообщения...");
            //Console.ReadLine();

            //// Send cancellation request to stop bot
            //cts.Cancel();
        }
    }

}

