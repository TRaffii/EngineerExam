using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EgzaminInzr
{
   
    public partial class Form1 : Form
    {
        #region fields
        int numberOfQuestionToExam = 5;
        private int actualQuestionId = 0;
        bool isAdmin = false;
        Answer[] answersRandomSequence = new Answer[3];
        bool isExamMode = false;
        bool isFastAnswersMode = false;
        public int QuestionFromRange { get; set; }
        public int QuestionToRange { get; set; }
        bool isLearningModeEnabled = false;
        Random rnd = new Random();
        bool isAnswerChoosen = false;
        List<Question> questionList = new List<Question>();
        Hashtable userAnswers = new Hashtable();
        int[] randomedQuestions;
        int randomActualQuestion = 0;
        int sumOfAllAnsweredQuestions = 0;
        #endregion
        #region buttonEvents
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (actualQuestionId == questionList.Count + 1 || randomActualQuestion == numberOfQuestionToExam)
                MessageBox.Show("To juz wszystkie pytania!");
            else
                LoadNextQuestion();
        }
        private void btnPrev_Click(object sender, EventArgs e)
        {
            if ((actualQuestionId == 1 && !isExamMode) || (randomActualQuestion == 0 && isExamMode))
                MessageBox.Show("Nie kombinuj...");
            else
            {
                if (isExamMode)
                {
                    LoadQuestion(randomedQuestions[randomActualQuestion - 1]);
                }
                else
                {
                    LoadQuestion(actualQuestionId - 1);
                }
            }
        }
        private void podgladOdpowiedziToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isLearningModeEnabled)
            {
                ((System.Windows.Forms.ToolStripMenuItem)sender).Checked = false;
                isLearningModeEnabled = false;
            }
            else
            {
                ((System.Windows.Forms.ToolStripMenuItem)sender).Checked = true;
                isLearningModeEnabled = true;
            }
            LoadQuestion(actualQuestionId);
        }
        private void btnGoTo_Click(object sender, EventArgs e)
        {

            try
            {
                LoadQuestion(Int32.Parse(txtGoto.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Jak dzieci...\n" + ex.Message);
            }

        }
        private void txtAnswerA_Click(object sender, EventArgs e)
        {
            SetAnswerChoosen();
            ((TextBox)sender).BackColor = Color.LightGreen;
            if (isAdmin)
            {
                questionList[actualQuestionId - 1].Answer = Answer.A;
            }
            else
            {
                AddUserAnswer(Answer.A);
            }
        }
        private void txtAnswerB_Click(object sender, EventArgs e)
        {
            SetAnswerChoosen();
            ((TextBox)sender).BackColor = Color.LightGreen;
            if (isAdmin)
            {
                questionList[actualQuestionId - 1].Answer = Answer.B;
            }
            else
            {
                AddUserAnswer(Answer.B);
            }
        }
        private void txtAnswerC_Click(object sender, EventArgs e)
        {
            SetAnswerChoosen();
            ((TextBox)sender).BackColor = Color.LightGreen;
            if (isAdmin)
            {
                questionList[actualQuestionId - 1].Answer = Answer.C;
            }
            else
            {
                AddUserAnswer(Answer.C);
            }
        }
        private void trybAdminaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tryb admina został zdezaktywowany");
            return;
            if (isAdmin)
            {
                ((System.Windows.Forms.ToolStripMenuItem)sender).Checked = false;
                isAdmin = false;
            }
            else
            {
                ((System.Windows.Forms.ToolStripMenuItem)sender).Checked = true;
                isAdmin = true;
            }
        }
        private void btnSaveToFileAnswers_Click(object sender, EventArgs e)
        {
            SaveToAnswerFile();
        }
        private void btnA_Click(object sender, EventArgs e)
        { 
            if (isAdmin)
            {
                questionList[actualQuestionId - 1].Answer = Answer.A;
            }
            else
            {
                AddUserAnswer(Answer.A);
            }
            if (!isFastAnswersMode)
                LoadNextQuestion();
            else
                if (CompareUserAnswerWithRealAnswer(Answer.A)) btnA.BackColor = Color.LightGreen;
                else
                    btnA.BackColor = Color.Red;
        }
        private void btnB_Click(object sender, EventArgs e)
        {
            if (isAdmin)
            {
                questionList[actualQuestionId - 1].Answer = Answer.B;
            }
            else
            {
                AddUserAnswer(Answer.B);
            }
            if (!isFastAnswersMode)
                LoadNextQuestion();
            else
                if (CompareUserAnswerWithRealAnswer(Answer.B)) btnB.BackColor = Color.LightGreen;
                else 
                    btnB.BackColor = Color.Red;
        }
        private void btnC_Click(object sender, EventArgs e)
        {
            if (isAdmin)
            {
                questionList[actualQuestionId - 1].Answer = Answer.C;
            }
            else
            {
                AddUserAnswer(Answer.C);
            }
            if (!isFastAnswersMode)
                LoadNextQuestion();
            else
                if (CompareUserAnswerWithRealAnswer(Answer.C)) btnC.BackColor = Color.LightGreen;
                else
                    btnC.BackColor = Color.Red;
        }
        private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void nowyTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetProgramToBasicMode();
            ActiveExamMode();
        }
        private void wszystkiePytaniaReloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetProgramToBasicMode();
            ResetAllQuestionPartsMenuItems();
            wszystkiePytaniaToolStripMenuItem1.Checked = true;
            QuestionFromRange = 1;
            QuestionToRange= 711;
            LoadQuestion(1);
        }
        private void nowyTestSzybkieOdpowiedziToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetProgramToBasicMode();
            isFastAnswersMode = true;
            ActiveExamMode();
        }
        private void pytan5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetQuestionsMenuItems();
            SetNewNumberOfQuestion(5);
            pytan5ToolStripMenuItem.Checked = true;
        }
        private void pytan10ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ResetQuestionsMenuItems();
            SetNewNumberOfQuestion(10);
            pytan10ToolStripMenuItem1.Checked = true;
           
        }

        private void pytan20ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ResetQuestionsMenuItems();
            SetNewNumberOfQuestion(20);
            pytan20ToolStripMenuItem2.Checked = true;
        }

        private void pytan40ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ResetQuestionsMenuItems();
            SetNewNumberOfQuestion(40);
            pytan40ToolStripMenuItem3.Checked = true;
        }

        private void pytan50EgzaminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetQuestionsMenuItems();
            SetNewNumberOfQuestion(50);
            pytan50EgzaminToolStripMenuItem.Checked = true;
        }
        #endregion
        #region events
        private void menuStrip1_LayoutCompleted(object sender, EventArgs e)
        {
             wszystkiePytaniaToolStripMenuItem1.Checked = true;
             pytan5ToolStripMenuItem.Checked = true;
        }
        #endregion
        public Form1()
        {
            InitializeComponent();
            QuestionFromRange = 1;
            QuestionToRange = 711;
            
        }

        private void ResetQuestionsMenuItems()
        {
            pytan5ToolStripMenuItem.Checked = false;
            pytan10ToolStripMenuItem1.Checked = false;
            pytan10ToolStripMenuItem1.Checked = false;
            pytan40ToolStripMenuItem3.Checked = false;
            pytan50EgzaminToolStripMenuItem.Checked = false;

        }
        private bool CompareUserAnswerWithRealAnswer(Answer answer)
        {
            ResetBackgroundTextColors();
            bool isAnswerCorrect = false;
            if (Equals(GetAnswerFromRandom(), answer)) isAnswerCorrect = true;
            if(!isAnswerCorrect)
                switch (GetAnswerFromRandom())
                {
                    case Answer.A:
                        btnA.BackColor = Color.LightGreen;
                        break;
                    case Answer.B:
                        btnB.BackColor = Color.LightGreen;
                        break;
                    case Answer.C:
                        btnC.BackColor = Color.LightGreen;
                        break;
                }
            return isAnswerCorrect;
        }
        private void SetNewNumberOfQuestion(int numberOfQuestions)
        {
            numberOfQuestionToExam = numberOfQuestions;
            randomedQuestions = new int[numberOfQuestionToExam];
        }
        private void ActiveExamMode()
        {
            isExamMode = true;
            randomActualQuestion = 0;
            sumOfAllAnsweredQuestions = 0;
            userAnswers.Clear();
            var exceptNumbers = Enumerable.Range(316, 26);
            var numbers = Enumerable.Range(QuestionFromRange, QuestionToRange - QuestionFromRange+1).Except(exceptNumbers);
            numbers = EnumerableFeatures.Shuffle(numbers).Take(numberOfQuestionToExam);
            int i = 0;
            foreach (var item in numbers)
            {
                randomedQuestions[i] = item;
                i++;
            }
            LoadQuestion(randomedQuestions[0]);
        }
        private void ResetProgramToBasicMode()
        {
            isExamMode = false;
            isFastAnswersMode = false;
        }
        public static void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[8 * 1024];
            int len;
            while ((len = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, len);
            }
        }
        private String GetTextToBorderElement(PeekableStreamReaderAdapter file, string border)
        {
            string line,returnText = string.Empty;
            bool isBorderString = false;
            while (!isBorderString)
            {
                if (file.BufferedLines.Count == 0)
                    line = file.PeekLine();
                else
                    line = file.ReadLine();
                if (!line.Contains(border))
                    returnText += " "+line;
                else
                    isBorderString = true;
            }
            return returnText;
        }
        private String GetTextToBorderElement(PeekableStreamReaderAdapter file, Regex regexMatch)
        {
            string line, returnText = string.Empty;
            bool isBorderString = false;
            while (!isBorderString)
            {
                if (file.BufferedLines.Count == 0)
                    line = file.PeekLine();
                else
                    line = file.ReadLine();
                if (!Equals(line,null) && !regexMatch.IsMatch(line))
                    returnText += " " + line;
                else
                    isBorderString = true;
            }
            return returnText;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            DirectoryInfo questionsDirectory = new DirectoryInfo("pytania");
            //Faster const 711
            randomedQuestions = new int[numberOfQuestionToExam];
            const int numberOfQuestions = 711;
            for (int i = 1; i <= numberOfQuestions; i++)
            {
                questionList.Add(new Question(i));
            }
            LoadAnswersToGlobalQuestionLostIfFIleExists();
            LoadQuestion(1);
           
        }
        private Answer GetAnswerTypeFromString(string ans)
        {
            Answer ansReturn = Answer.Unknown;
            switch (ans)
            {
                case "A":
                    ansReturn = Answer.A;
                break;
                case "B":
                    ansReturn = Answer.B;
                break;
                case "C":
                    ansReturn = Answer.C;
                break;
            }
            return ansReturn;
        }
        private void LoadAnswersToGlobalQuestionLostIfFIleExists()
        {
            
            string fileName = "Answers.txt";
            if (File.Exists(fileName))
            {
                System.IO.StreamReader file =
                 new System.IO.StreamReader(fileName, System.Text.Encoding.UTF8);
                
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] ans = line.Split(':');
                    if (!Equals(ans[1], Answer.Unknown.ToString()))
                    {
                        try
                        {
                            questionList[Int32.Parse(ans[0]) - 1].Answer = GetAnswerTypeFromString(ans[1]);
                        }
                        catch (Exception)
                        {
                          
                        }
                        
                    }
                }
            }
        }
        private void ResetBackgroundTextColors()
        {
            btnA.BackColor = Color.FromName("White");
            btnB.BackColor = Color.FromName("White");
            btnC.BackColor = Color.FromName("White"); 
        }
        private void SetImageToPictureBox(Image image,int row)
        {
            tableLayoutPanel1.RowStyles[row].Height = image.Height > 70 ? image.Height : 70;
            switch (row)
            {
                case 1:
                    picAnswer1.Width = image.Width;
                    picAnswer1.Height = image.Height;
                    picAnswer1.Image = image;
                break;
                case 2:
                    picAnswer2.Width = image.Width;
                    picAnswer2.Height = image.Height;
                    picAnswer2.Image = image;
                break;
                case 3:
                    picAnswer3.Width = image.Width;
                    picAnswer3.Height = image.Height;
                    picAnswer3.Image = image;
                break;
            }
        }
        private void RandomAnswersInQuestion(int questionNumber)
        {
            
            for (int i = 0; i < 3; i++)
            {
                answersRandomSequence[i] = Answer.Unknown;
            }
            string directory = "pytania";
            int first = rnd.Next(1, 4),second=rnd.Next(1, 4),third=rnd.Next(1, 4);
            Image answerAImage = Image.FromFile(Path.Combine(directory, string.Format("{0}.a.jpg", questionNumber)));
            SetImageToPictureBox(answerAImage, first);

            answersRandomSequence[first - 1] = Answer.A;
            while (second == first) second = rnd.Next(1, 4);
            Image answerBImage = Image.FromFile(Path.Combine(directory, string.Format("{0}.b.jpg", questionNumber)));
            SetImageToPictureBox(answerBImage, second);
            answersRandomSequence[second - 1] = Answer.B;
            while (third == first || third==second) third = rnd.Next(1, 4);

            Image answerCImage = Image.FromFile(Path.Combine(directory, string.Format("{0}.c.jpg", questionNumber)));
            SetImageToPictureBox(answerCImage, third);
            answersRandomSequence[third - 1] = Answer.C;
        }
        private void LoadQuestion(int questionNumber)
        {
            if (questionNumber >= questionList.Count + 1 || (randomActualQuestion >= numberOfQuestionToExam && isExamMode) || questionNumber > QuestionToRange || questionNumber<QuestionFromRange)
            {
                MessageBox.Show("To juz wszystkie pytania!");
                if(isExamMode) CheckResult();
                return;
            }
            string directory = "pytania";
            ResetBackgroundTextColors();
            isAnswerChoosen = false;
            if (isExamMode)
            {
                int keyIndex = Array.FindIndex(randomedQuestions, w => w == questionNumber);
                randomActualQuestion = keyIndex;
                actualQuestionId = questionNumber;
            }
            else
            {
                actualQuestionId = questionNumber;
            }
            
            //txtQuestion.Text = questionList[questionNumber - 1].QuestionText;
            Image questionImage = Image.FromFile(Path.Combine(directory, string.Format("{0}.p.jpg", questionNumber)));
            tableLayoutPanel1.RowStyles[0].Height = questionImage.Height;
            picQuestion.Width = questionImage.Width;
            picQuestion.Height = questionImage.Height;
            picQuestion.Image = questionImage;
            RandomAnswersInQuestion(questionNumber);
           

           

            //txtAnswerA.Text = questionList[questionNumber - 1].Answers[0];
            //txtAnswerB.Text = questionList[questionNumber - 1].Answers[1];
            //txtAnswerC.Text = questionList[questionNumber - 1].Answers[2];
            grpBox.Text = "Pytanie " + questionList[questionNumber - 1].ID;
            txtGoto.Text = actualQuestionId.ToString();
            if (isAdmin || isLearningModeEnabled)
            {

                switch (questionList[questionNumber - 1].Answer)
                {
                    case Answer.Unknown:
                        break;
                    case Answer.A:
                        GetButtonFromAnswer(Answer.A).BackColor = Color.LightGreen;
                        break;
                    case Answer.B:
                        GetButtonFromAnswer(Answer.B).BackColor = Color.LightGreen;
                        break;
                    case Answer.C:
                        GetButtonFromAnswer(Answer.C).BackColor = Color.LightGreen;
                        break;
                }
            }
        }
        private Button GetButtonFromAnswer(Answer answer)
        {
            int keyIndex = Array.FindIndex(answersRandomSequence, w => w==answer);
            switch (keyIndex)
            {
                case 0:
                    return btnA;
                case 1:
                    return btnB;
                case 2:
                    return btnC;
            }
            return btnA;
        }
        private Answer GetRealAnswer(Answer answer)
        {
            int keyIndex = Array.FindIndex(answersRandomSequence, w => w == answer);
            switch (keyIndex)
            {
                case 0:
                    return Answer.A;
                case 1:
                    return Answer.B;
                case 2:
                    return Answer.C;
            }
            return Answer.Unknown;
        }
        private void SetOnHoverBackground(object sender)
        {
            if (!isAnswerChoosen)
                ((TextBox)sender).BackColor = Color.Orange;
        }
        private void SetOnLeaveBackground(object sender)
        {
            if (!isAnswerChoosen)
                ((TextBox)sender).BackColor = Color.FromName("Menu");
        }
        private void SaveToAnswerFile()
        {
            string fileName = "Answers.txt";
            // Write the stream contents to a new file named "AllTxtFiles.txt".
            using (StreamWriter outfile = new StreamWriter(fileName))
            {
                foreach (var question in questionList)
	            {
                    outfile.WriteLine(question.ID + ":" + question.Answer);
	            }
                
            }
            Process.Start("notepad.exe", fileName);
        }
        private void SetAnswerChoosen()
        {
            ResetBackgroundTextColors();
            isAnswerChoosen = true;
        }
        private Answer GetAnswerFromRandom()
        {
            switch (questionList[actualQuestionId - 1].Answer)
            {
                case Answer.Unknown:
                    break;
                case Answer.A:
                    return GetRealAnswer(Answer.A);
                case Answer.B:
                    return GetRealAnswer(Answer.B);
                case Answer.C:
                    return GetRealAnswer(Answer.C);
            }
            return Answer.Unknown;
        }
        private void AddUserAnswer(Answer answer)
        {
            if (!userAnswers.ContainsKey(actualQuestionId))
            {
                sumOfAllAnsweredQuestions += 1;
                userAnswers.Add(actualQuestionId, new UserAnswer(answer, GetAnswerFromRandom()));
            }
            else
                userAnswers[actualQuestionId] = new UserAnswer(answer, GetAnswerFromRandom());
        }
        private void CheckResult()
        {
            List<string> answers = new List<string>();
            int i = 1;
            foreach (var item in userAnswers.Keys)
            {
                UserAnswer val = (UserAnswer)userAnswers[item];
                string ans = string.Empty;
                ans += (string.Format("Pytanie {0} ({1}) ", i, item));
                if (Equals(val.RealAnswer, val.UserAns))
                {
                    ans += "OK!";
                }
                else
                {
                    ans += string.Format("ERROR! Powinno być {0}, Ty wybrałeś {1}",val.RealAnswer,val.UserAns);
                }
                answers.Add(ans);
                i++;
            }
            TestResult rsltForm = new TestResult(answers);
            rsltForm.Show();
        }
        private void LoadNextQuestion()
        {
            if (isExamMode)
            {
                if (randomActualQuestion == numberOfQuestionToExam-1)
                {
                    MessageBox.Show("To już wszystkie pytania");
                    if (sumOfAllAnsweredQuestions == numberOfQuestionToExam || QuestionToRange - QuestionFromRange < numberOfQuestionToExam)
                        CheckResult();
                    return;
                }
                LoadQuestion(randomedQuestions[randomActualQuestion + 1]);
            }
            else
            {
                LoadQuestion(actualQuestionId + 1);
            }
        }
    }
    public class UserAnswer
    {
        public Answer UserAns { get; set; }
        public Answer RealAnswer { get; set; }

        public UserAnswer(Answer u, Answer r)
        {
            UserAns = u;
            RealAnswer = r;
        }
    };
}
