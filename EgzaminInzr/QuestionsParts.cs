using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgzaminInzr
{
    partial class Form1
    {
        private void ResetAllQuestionPartsMenuItems()
        {
            wszystkiePytaniaToolStripMenuItem1.Checked = false;
            wstępDoProgramowaniaCToolStripMenuItem.Checked = false;
            ochronaŚrodowiskaToolStripMenuItem.Checked = false;
            bHPToolStripMenuItem.Checked = false;
            architekturaKomputerówToolStripMenuItem.Checked = false;
            algorytmyToolStripMenuItem.Checked = false;
            statystykaToolStripMenuItem.Checked = false;
            systemyOperacyjneToolStripMenuItem.Checked = false;
            metaloznastwoToolStripMenuItem.Checked = false;
            programowanieObiektoweToolStripMenuItem.Checked = false;
            mTIToolStripMenuItem.Checked = false;
            mechanikaPłynówToolStripMenuItem.Checked = false;
            ekonomikaToolStripMenuItem.Checked = false;
            metodyNumeryczneToolStripMenuItem.Checked = false;
            sieciToolStripMenuItem.Checked = false;
            bazyDanychToolStripMenuItem.Checked = false;
            javaToolStripMenuItem.Checked = false;
            grafikaToolStripMenuItem.Checked = false;
            patentyToolStripMenuItem.Checked = false;
            PSIStripMenuItem.Checked = false;
            inzynieriaOprogramowaniaStripMenuItem.Checked = false;
            inzynieriaInternetuStripMenuItem.Checked = false;
            programowanieRownolegleToolStripMenuItem.Checked = false;
            MESToolStripMenuItem.Checked = false;
            WCiMToolStripMenuItem.Checked = false;
        }
        private void LoadRangeQuestion()
        {
            ResetProgramToBasicMode();
            LoadQuestion(QuestionFromRange);
        }
        private void wszystkiePytaniaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ResetAllQuestionPartsMenuItems();
            wszystkiePytaniaToolStripMenuItem1.Checked = true;
            QuestionFromRange = 1;
            QuestionToRange = 711;
            LoadRangeQuestion();
        }

        private void wstępDoProgramowaniaCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetAllQuestionPartsMenuItems();
            wstępDoProgramowaniaCToolStripMenuItem.Checked = true;
            QuestionFromRange = 1;
            QuestionToRange = 30;
            LoadRangeQuestion();
        }

        private void ochronaŚrodowiskaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetAllQuestionPartsMenuItems();
            ochronaŚrodowiskaToolStripMenuItem.Checked = true;
            QuestionFromRange = 31;
            QuestionToRange = 50;
            LoadRangeQuestion();
        }
        private void bHPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetAllQuestionPartsMenuItems();
            bHPToolStripMenuItem.Checked = true;
            QuestionFromRange = 51;
            QuestionToRange = 57;
            LoadRangeQuestion();
        }

        private void architekturaKomputerówToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetAllQuestionPartsMenuItems();
            architekturaKomputerówToolStripMenuItem.Checked = true;
            QuestionFromRange = 58;
            QuestionToRange = 91;
            LoadRangeQuestion();
        }

        private void algorytmyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetAllQuestionPartsMenuItems();
            algorytmyToolStripMenuItem.Checked = true;
            QuestionFromRange = 92;
            QuestionToRange = 119;
            LoadRangeQuestion();
        }

        private void statystykaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetAllQuestionPartsMenuItems();
            statystykaToolStripMenuItem.Checked = true;
            QuestionFromRange = 120;
            QuestionToRange = 149;
            LoadRangeQuestion();
        }

        private void systemyOperacyjneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetAllQuestionPartsMenuItems();
            systemyOperacyjneToolStripMenuItem.Checked = true;
            QuestionFromRange = 150;
            QuestionToRange = 199;
            LoadRangeQuestion();
        }

        private void metaloznastwoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetAllQuestionPartsMenuItems();
            metaloznastwoToolStripMenuItem.Checked = true;
            QuestionFromRange = 200;
            QuestionToRange = 228;
            LoadRangeQuestion();
        }

        private void programowanieObiektoweToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetAllQuestionPartsMenuItems();
            programowanieObiektoweToolStripMenuItem.Checked = true;
            QuestionFromRange = 229;
            QuestionToRange = 255;
            LoadRangeQuestion();
        }

        private void mTIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetAllQuestionPartsMenuItems();
            mTIToolStripMenuItem.Checked = true;
            QuestionFromRange = 256;
            QuestionToRange = 285;
            LoadRangeQuestion();
        }

        private void mechanikaPłynówToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetAllQuestionPartsMenuItems();
            mechanikaPłynówToolStripMenuItem.Checked = true;
            QuestionFromRange = 286;
            QuestionToRange = 315;
            LoadRangeQuestion();
        }

        private void ekonomikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetAllQuestionPartsMenuItems();
            ekonomikaToolStripMenuItem.Checked = true;
            QuestionFromRange = 342;
            QuestionToRange = 362;
            LoadRangeQuestion();
        }

        private void metodyNumeryczneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetAllQuestionPartsMenuItems();
            metodyNumeryczneToolStripMenuItem.Checked = true;
            QuestionFromRange = 363;
            QuestionToRange = 392;
            LoadRangeQuestion();
        }

        private void sieciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetAllQuestionPartsMenuItems();
            sieciToolStripMenuItem.Checked = true;
            QuestionFromRange = 393;
            QuestionToRange = 425;
            LoadRangeQuestion();
        }

        private void bazyDanychToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetAllQuestionPartsMenuItems();
            bazyDanychToolStripMenuItem.Checked = true;
            QuestionFromRange = 426;
            QuestionToRange = 466;
            LoadRangeQuestion();
        }

        private void javaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetAllQuestionPartsMenuItems();
            javaToolStripMenuItem.Checked = true;
            QuestionFromRange = 467;
            QuestionToRange = 496;
            LoadRangeQuestion();
        }

        private void grafikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetAllQuestionPartsMenuItems();
            grafikaToolStripMenuItem.Checked = true;
            QuestionFromRange = 497;
            QuestionToRange = 523;
            LoadRangeQuestion();
        }

        private void patentyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetAllQuestionPartsMenuItems();
            patentyToolStripMenuItem.Checked = true;
            QuestionFromRange = 524;
            QuestionToRange = 550;
            LoadRangeQuestion();
        }

        private void PSIStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetAllQuestionPartsMenuItems();
            PSIStripMenuItem.Checked = true;
            QuestionFromRange = 551;
            QuestionToRange = 576;
            LoadRangeQuestion();
        }

        private void inzynieriaOprogramowaniaStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetAllQuestionPartsMenuItems();
            inzynieriaOprogramowaniaStripMenuItem.Checked = true;
            QuestionFromRange = 577;
            QuestionToRange = 605;
            LoadRangeQuestion();
        }

        private void inzynieriaInternetuStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetAllQuestionPartsMenuItems();
            inzynieriaInternetuStripMenuItem.Checked = true;
            QuestionFromRange = 606;
            QuestionToRange = 635;
            LoadRangeQuestion();
        }

        private void programowanieRownolegleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetAllQuestionPartsMenuItems();
            programowanieRownolegleToolStripMenuItem.Checked = true;
            QuestionFromRange = 636;
            QuestionToRange = 655;
            LoadRangeQuestion();
        }

        private void MESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetAllQuestionPartsMenuItems();
            MESToolStripMenuItem.Checked = true;
            QuestionFromRange = 656;
            QuestionToRange = 683;
            LoadRangeQuestion();
        }

        private void WCiMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetAllQuestionPartsMenuItems();
            WCiMToolStripMenuItem.Checked = true;
            QuestionFromRange = 684;
            QuestionToRange = 711;
            LoadRangeQuestion();
        }

    }
}
