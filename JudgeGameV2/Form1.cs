using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace JudgeGameV2
{
    /// <summary>
    /// The biggest things that can be improved is the amount of original picture boxes, since there are only 4 different pictures 
    /// </summary>
    public partial class Form1 : Form
    {
        Queue<Prisoner> queue = new Queue<Prisoner>();
        List<Prisoner> prisoners = new List<Prisoner>();
        SoundPlayer player = new SoundPlayer();
        int strike; //holds onto the amount of strikes the user has
        public Form1()
        {
            InitializeComponent();
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            prisoners = new List<Prisoner>(); //starts the list
            prisoners.Add(new Prisoner() { Crime = "Jaywalking", PictureBox = Prisoner1, RecommitStart = 0, RecommitEnd = 11 });
            prisoners.Add(new Prisoner() {  Crime = "Shoplifting", PictureBox = Prisoner2, RecommitStart = 1, RecommitEnd = 10 });
            prisoners.Add(new Prisoner() {Crime = "Arson", PictureBox = Prisoner3, RecommitStart = 4, RecommitEnd = 7 });
            prisoners.Add(new Prisoner() {Crime = "Tax Evasion", PictureBox = Prisoner4, RecommitStart = 3, RecommitEnd = 7 });
            prisoners.Add(new Prisoner() {Crime = "Speeding", PictureBox = Prisoner5, RecommitStart = 2, RecommitEnd = 7 });
            prisoners.Add(new Prisoner() {Crime = "Armed Robbery", PictureBox = Prisoner6, RecommitStart = 4, RecommitEnd = 6 });
            prisoners.Add(new Prisoner() {Crime = "Money Laundering", PictureBox = Prisoner7, RecommitStart = 3, RecommitEnd = 7 });
            prisoners.Add(new Prisoner() {Crime = "Insider Trading", PictureBox = Prisoner8, RecommitStart = 3, RecommitEnd = 7 });
            prisoners.Add(new Prisoner() {Crime = "Perjury", PictureBox = Prisoner9, RecommitStart = 3, RecommitEnd = 7 });
            prisoners.Add(new Prisoner() {Crime = "Forgery", PictureBox = Prisoner10, RecommitStart = 3, RecommitEnd = 7 });
            prisoners.Add(new Prisoner() {Crime = "Disorderly Conduct", PictureBox = Prisoner11, RecommitStart = 1, RecommitEnd = 9 });
            prisoners.Add(new Prisoner() {Crime = "Insurance Fraud", PictureBox = Prisoner12, RecommitStart = 2, RecommitEnd = 8 });
            prisoners.Add(new Prisoner() {Crime = "Vandalism", PictureBox = Prisoner13, RecommitStart = 3, RecommitEnd = 7 });
            prisoners.Add(new Prisoner() {Crime = "Identity Theft", PictureBox = Prisoner14, RecommitStart = 3, RecommitEnd = 7 });
            prisoners.Add(new Prisoner() {Crime = "Disturbing the Peace", PictureBox = Prisoner15, RecommitStart = 3, RecommitEnd = 7 });
            prisoners.Add(new Prisoner() {Crime = "Accessory", PictureBox = Prisoner16, RecommitStart = 3, RecommitEnd = 7 });
            prisoners.Add(new Prisoner() {Crime = "Boating without a License ", PictureBox = Prisoner17, RecommitStart = 4, RecommitEnd = 6 });
            prisoners.Add(new Prisoner() {Crime = "Malpractice", PictureBox = Prisoner18, RecommitStart = 3, RecommitEnd = 7 });
            prisoners.Add(new Prisoner() {Crime = "Bribery", PictureBox = Prisoner19, RecommitStart = 3, RecommitEnd = 7 });
            prisoners.Add(new Prisoner() {Crime = "Murder", PictureBox = Prisoner20, RecommitStart = 4, RecommitEnd = 6 });
            prisoners.Add(new Prisoner() { Crime = "Charging too high prices", PictureBox = Prisoner21, RecommitStart = 4, RecommitEnd = 6, soundPlayer = @"C:\Users\Owner\Downloads\Untitled video - Made with Clipchamp (1).wav" });
            prisoners.Add(new Prisoner() { Crime = "Organized Crime", PictureBox = Prisoner22, RecommitStart = 4, RecommitEnd = 6 } );
            prisoners.Add(new Prisoner() { Crime = "Treason", PictureBox = Prisoner23, RecommitStart = 4, RecommitEnd = 6 });
            prisoners.Add(new Prisoner() { Crime = "Cigarette Smuggling", PictureBox = Prisoner24, RecommitStart = 2, RecommitEnd = 8 });
            prisoners.Add(new Prisoner() { Crime = "Counterfeiting", PictureBox = Prisoner25, RecommitStart = 3, RecommitEnd = 7 });
            prisoners.Add(new Prisoner() { Crime = "Cyber Crime", PictureBox = Prisoner26, RecommitStart = 3, RecommitEnd = 7 });
            prisoners.Add(new Prisoner() { Crime = "WMD Possession", PictureBox = Prisoner27, RecommitStart = 4, RecommitEnd = 6 });
            prisoners.Add(new Prisoner() { Crime = "Piracy", PictureBox = Prisoner28, RecommitStart = 1, RecommitEnd = 9 });
            prisoners.Add(new Prisoner() { Crime = "Trespassing", PictureBox = Prisoner29, RecommitStart = 2, RecommitEnd = 8 });


            retxtStrikes.Visible = false;
            lblStrikes.Visible = false;
            prisoners.Shuffle(); //randomizes list
            queue = new Queue<Prisoner>(6);//
            
            //After days of attempting to figure out how to duplicate pictureBoxes failing I had to assign each object with an original pictureBox :'(
            Prisoner1.Visible = false; Prisoner2.Visible = false; Prisoner3.Visible = false; Prisoner4.Visible = false; Prisoner5.Visible = false; Prisoner6.Visible = false; Prisoner7.Visible = false; Prisoner8.Visible = false;Prisoner9.Visible = false; Prisoner10.Visible = false;Prisoner11.Visible=false; Prisoner12.Visible = false;Prisoner13.Visible = false; Prisoner14.Visible = false;Prisoner15.Visible=false; Prisoner16.Visible = false;Prisoner17.Visible=false; Prisoner18.Visible=false;Prisoner19.Visible=false;Prisoner20.Visible=false; Prisoner21.Visible=false;Prisoner22.Visible=false;Prisoner23.Visible=false;Prisoner24.Visible=false;Prisoner25.Visible=false;Prisoner26.Visible=false;Prisoner27.Visible = false;Prisoner28.Visible = false;Prisoner29.Visible = false;

            Prisoner prisoner = prisoners[0]; //graps the first object in the prisoner list
            retxtCrime.Text = prisoner.Crime; //displays the objects crime
            Extensions.Display(prisoner.PictureBox); //takes the objects picturebox and uses the display function to make it visible
            Extensions.Move(prisoner.PictureBox,403,735,240,231); //moves the object's picturebox to the beginning spot to be judged
            
            if (prisoner.soundPlayer != null) //this is incase the first prisoner out of the list is specifically Prisoner21
            {
                player.SoundLocation = prisoner.soundPlayer;//takes the prisoners sound
                player.Play();//plays the prisoners sound
            }
        }
        private void btnFree_Click(object sender, EventArgs e)
        {
            timer1.Stop();//this will reset the timer to 0
            progressBar1.Value = 0;//reset the progress bar to 0
            Prisoner prisoner2 = prisoners[0];//grabs the next first object in the prisoner list
            
            var rand = new Random();
            int num = rand.Next(prisoner2.RecommitStart, prisoner2.RecommitEnd); //takes the range establish in each object , chooses a random number within that range
            if (num == 5) //if that number is 5
            {
                strike++;//a strike will be added to your tally
                retxtStrikes.Visible = true;//number of strikes will be displayed
                lblStrikes.Visible = true;//strike label will appear for your benefit
                retxtStrikes.Text = strike.ToString();//the current value of strikes
                if (strike == 3) //if you have 3 strikes
                {
                    player.SoundLocation = @"C:\Users\Owner\Downloads\wah-wah-sad-trombone-6347.wav"; //sad trombone music
                    player.Play();//sad trombone music play
                    MessageBox.Show("Wow, you're are a horrible judge of character, YOU LOSE!");//message box for losing
                    Application.Exit();//exits the application
                }
                player.SoundLocation = @"C:\Users\Owner\Downloads\Untitled video - Made with Clipchamp (3).wav"; //woop, woop
                player.Play();
                MessageBox.Show("The criminal recommitted");//message box displays warning said object recommitted
            }
            else if (prisoners.Count > 1)//if the prisoner didn't recommit
            {
                player.SoundLocation = @"C:\Users\Owner\Downloads\Untitled video - Made with Clipchamp (2).wav"; //freedom
                player.Play();
                Prisoner prisoner = prisoners[0]; // the current prisoner
                prisoners.RemoveAt(0);//the current prisoner is removed from list
                prisoner.PictureBox.Visible = false;//the current prisoner's picturebox is removed
                Prisoner prisoner1 = prisoners[0];//the next prisoner (now the first prisoner) is grabbed
                retxtCrime.Text=prisoner1.Crime; //their crime is displayd
                Extensions.Display(prisoner1.PictureBox);//displays their picture
                Extensions.Sound(prisoner1.soundPlayer);//if they have a sound it will play
                Extensions.Move(prisoner1.PictureBox, 403, 735,240,231);//moves their picture to the start
            }
            else
            {
                MessageBox.Show("Game Complete");
            }
            timer1.Start();//timer starts at 0

        }

        private async void btnJail_Click(object sender, EventArgs e)
        {
            if (queue.Count < 6 && prisoners.Count > 1) //if the queue is not greater than 6 and the list has more than 1 objects
            {
                progressBar1.Value = 0;//resets the progress bar to 0

                timer1.Interval = 1000; //sets the interval to 1 second
                
                timer1.Stop();//timer stops

                Prisoner prisoner = prisoners[0];//first position in randomized list
                queue.Enqueue(prisoner);//Enqueue the prisoner into prison
                prisoners.RemoveAt(0); //remove prisoner from list
                Extensions.Display(prisoner.PictureBox);//display the picture of the prisoner
                Extensions.Move(prisoner.PictureBox,697,237,187,176); //moves prisoners (hypothetically) to Cell 1
                player.SoundLocation = @"C:\Users\Owner\Downloads\Untitled video - Made with Clipchamp.wav"; //play sound of cell closing
                player.Play();
                
                Prisoner newPrisoner = prisoners[0];//grabs the next person from the randomized list
                retxtCrime.Text = newPrisoner.Crime;//displays their crime
                Extensions.Display(newPrisoner.PictureBox);//displays their picture
                Extensions.Sound(newPrisoner.soundPlayer);//plays their sound if they have one
                Extensions.Move(newPrisoner.PictureBox, 403, 735, 240, 231);//moves their picture to the start
                timer1.Start();//restarts the timer
                
               
                if(queue.Count == 2) 
                {
                    Extensions.Move(queue.Peek().PictureBox,951,237,187,176);//Cell 2
                }
                if (queue.Count == 3)
                {
                    Extensions.Move(queue.Peek().PictureBox, 697,524,187,176);//Cell 3
                    Extensions.Move(queue.ElementAt(1).PictureBox, 951, 237, 187, 176);
                }
                if (queue.Count == 4)
                {
                    Extensions.Move(queue.Peek().PictureBox, 951, 524,187,176);//Cell 4
                    Extensions.Move(queue.ElementAt(1).PictureBox, 697, 524,187,176);
                    Extensions.Move(queue.ElementAt(2).PictureBox, 951, 237, 187, 176);
                }
                if (queue.Count == 5)
                {
                    Extensions.Move(queue.Peek().PictureBox, 500, 445,178,178);//Cell 5
                    Extensions.Move(queue.ElementAt(1).PictureBox, 951, 524, 187, 176);
                    Extensions.Move(queue.ElementAt(2).PictureBox, 697, 524, 187, 176);
                    Extensions.Move(queue.ElementAt(3).PictureBox, 951, 237, 187, 176);
                }
                if (queue.Count == 6)
                {
                    Extensions.Move(queue.Peek().PictureBox, 1161, 445,178,178);//Cell 6
                    Extensions.Move(queue.ElementAt(1).PictureBox, 500, 445, 178, 178);
                    Extensions.Move(queue.ElementAt(2).PictureBox, 951, 524, 187, 176);
                    Extensions.Move(queue.ElementAt(3).PictureBox, 697, 524, 187, 176);
                    Extensions.Move(queue.ElementAt(4).PictureBox, 951, 237, 187, 176);

                }
                await Task.Delay(25000);//Each object will spend 25 seconds in prison (time in prison)
                queue.Dequeue(); //Removes object from prison after task delay (freedom)
                prisoner.PictureBox.Visible = false; //prisoners picture goes away
            }
            else if(prisoners.Count == 1) //if there is only one object left in the list
            {
                MessageBox.Show("Game Complete"); //you will
                Application.Exit();
            }
            else //if you attemp to queue more than 6 object into the queue
            {
                MessageBox.Show("There is no room left!");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            progressBar1.Increment(20);//increments the progressbar with each tick by 20%
            if (progressBar1.Value >= 100) // If 5 seconds have elapsed
            {
                timer1.Stop(); // Stop the timer
                strike++; //stike is added
                retxtStrikes.Visible = true;
                lblStrikes.Visible = true;
                retxtStrikes.Text = strike.ToString();
                if (strike == 3) //if you have 3 strikes
                {
                    player.SoundLocation = @"C:\Users\Owner\Downloads\wah-wah-sad-trombone-6347.wav";//sad sound effect
                    player.Play();
                    MessageBox.Show("You took too long deciding the fate of another person's life, YOU LOSE!"); //you lose
                    Application.Exit();//application ends
                }
                
                MessageBox.Show("Time's up! The criminal escaped and recommitted."); //MessageBox displays informing you have taken too longer to decide
                
            }

        }
    }
    public static class Extensions
    {
        public static Random rng = new Random();
        public static void Shuffle<T>(this IList<T> values)
        {
            for (int i = values.Count - 1; i > 0; i--) //math
            {
                int k = rng.Next(i + 1);//more math
                T value = values[k];//even more math
                values[k] = values[i];//also math
                values[i] = value;// can you guess that there was more math
            }
        }
        public static void Display(PictureBox pictureBox)
        {
           
            pictureBox.Visible = true;
        }
        public static void Move(PictureBox pictureBox, int x,int y,int h, int w)
        { 
            pictureBox.Size = new Size(h, w);
            pictureBox.Location = new Point(x,y);
        }
        public static void Sound(string str)
        {
            if(str != null)
            {
                SoundPlayer player = new SoundPlayer();
                player.SoundLocation = str;
                player.Play();
            }
        }

        

    }
}
