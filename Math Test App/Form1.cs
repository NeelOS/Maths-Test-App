using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IND_Maths_test
{
    public partial class Form1 : Form
    {
        System.Media.SoundPlayer finishSoundPlayer = new System.Media.SoundPlayer(@"C:\Windows\Media\tada.wav");
        System.Media.SoundPlayer sorrySoundPlayer = new System.Media.SoundPlayer(@"C:\Windows\Media\Windows Critical Stop.wav");
        Random randomizer = new Random();
        int add1;
        int add2;
        int minuend;
        int subtrahend;
        int multiplicant;
        int multiplier;
        int dividend;
        int divisior;
        int timeleft;
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Start the quiz by filling in all of the problems
        /// and starting the timer.
        /// </summary>

        public void StartTheTest()
        {
            // For the addition problem
            add1=randomizer.Next(51);
            add2=randomizer.Next(51);
            plusLeftLabel.Text=add1.ToString();
            plusRightLabel.Text = add2.ToString();
            sum.Value=0;

            //for substraction problem
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            //for multiplication problem
            multiplicant = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLable.Text = multiplicant.ToString();
            timesRightLable.Text = multiplier.ToString();
            product.Value = 0;

            //for division problem
            divisior = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisior * temporaryQuotient;
            divideLeftLable.Text = dividend.ToString();
            divideRightLable.Text=divisior.ToString();
            quotient.Value=0;
            
            //start the timer
            timeleft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheTest();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(CheckTheAnswere())
            {
                timer1.Stop();
                finishSoundPlayer.Play();
                MessageBox.Show("Congratualtion!! you've got all answeres correct");
                startButton.Enabled=true;
            }
            else if (timeleft > 0)
            {
                if (timeleft <= 10)
                {
                    timeLabel.BackColor = Color.Red;
                }
                timeleft = timeleft - 1;
                timeLabel.Text = timeleft + "seconds";
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time is up";
                timeLabel.BackColor = DefaultBackColor;
                sorrySoundPlayer.Play();
                MessageBox.Show("You didn't finish in time. sorry");
                sum.Value = add1 + add2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplier * multiplicant;
                quotient.Value = dividend / divisior;
                startButton.Enabled = true;
            }
        }
        private bool CheckTheAnswere()
        {
            if ((add1 + add2 == sum.Value)&&(minuend-subtrahend==difference.Value)&&(multiplicant*multiplier==product.Value)&&(dividend/divisior==quotient.Value))
                return true;
            else
                return false;
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answereBox = sender as NumericUpDown;
            if (answereBox != null)
            {
                int LengthOfAnswer = answereBox.Value.ToString().Length;
                answereBox.Select(0, LengthOfAnswer);
            }
        }

    }
}
