using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private static Telegram.Bot.TelegramBotClient BOT;

        public ListBox listbox2 { get; private set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BOT = new Telegram.Bot.TelegramBotClient("744578703:AAFel2eXEWWYrsiplEPhxgxNCd2BSLumYmQ");
            BOT.OnMessage += BotOnMessageReceived;
            BOT.StartReceiving();
            button1.Enabled = false;


        }

        private async void BotOnMessageReceived(object sender, MessageEventArgs e)
        {
            String Answer = "";
            
            if (e.Message == null) return;
            switch (e.Message.Text)
            {
                case "/start": Answer = "/stone - твой камень\r\n/scissors - твои ножницы\r\n/paper - твоя бумага\r\n/baba - показать смачную бабу"; break;
                case "/help": Answer = "А у меня бумага - ты проиграл"; break;
                case "/scissors": Answer = "А у меня камень - ты проиграл"; break;
                case "/paper": Answer = "А у меня ножницы - ты проиграл"; break;
                case "/baba": Answer = "Вот тебе баба - "; break;
                default: Answer = "Не знаю такой команды"; break;
            }
            //e.Message.Text = Answer;
            //listBox1.Items.Add($"Received a text message in chat {e.Message.Chat.Id}.");

            Action action = () =>  listBox1.Items.Add("Received message");
            Invoke(action);
            await BOT.SendTextMessageAsync(chatId: e.Message.Chat, text: "" + Answer);
            //listadd(Convert.ToInt32(e.Message.Chat.Id),Answer);

            new ListBox();
            //var sync = WindowsFormsSynchronizationContext.Current;
            //sync.Post(
            //    delegate
            //    {
            //        listBox1.Items.Add("Received message");
            //    },
            //    null);

           // Telegram.Bot.Types.Message msg = new Telegram.Bot.Types.Message();
            

        }

        public void listadd(int id, string text = "")
        {
            if (text != null)
            {
                listBox1.Items.Add($"Message - {text}, id - {id}");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListBox listbox2 = new ListBox();
            this.Controls.Add(listbox2); 
            listbox2.Location = new Point (150,150);
            
              
            
        }
    }
}
