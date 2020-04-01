using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeachDemo.Models;

namespace TeachDemo
{
  public partial class FrmMain : Form
  {
    private Paper paper = new Paper();//试卷对象

    private int questionIndex = 0;//当前试题序号

    public FrmMain()
    {
      InitializeComponent();

    }
    //抽取试题
    private void btnExtract_Click(object sender, EventArgs e)
    {
      paper.ExtractQuestions();
      //隐藏掉面板和按钮
      this.panelPaper.Visible = false;
      this.btnExtract.Visible = false;
      //显示第一题
      ShowQuestion();
    }
    /// <summary>
    /// 根据索引显示题目
    /// </summary>
    private void ShowQuestion()
    {
      this.lblTitle.Text = paper.Questions[this.questionIndex].Title;
      this.lblA.Text = paper.Questions[this.questionIndex].OptionA;
      this.lblB.Text = paper.Questions[this.questionIndex].OptionB;
      this.lblC.Text = paper.Questions[this.questionIndex].OptionC;
      this.lblD.Text = paper.Questions[this.questionIndex].OptionD;
    }

    //上一题
    private void btnPre_Click(object sender, EventArgs e)
    {
      if (questionIndex == 0) return;
      else
      {
        SaveAnswer();
        this.questionIndex--;
        ShowQuestion();
        ResetAnswer();
      }
    }
    //下一题
    private void btnNext_Click(object sender, EventArgs e)
    {
      if (questionIndex == this.paper.Questions.Count - 1) return;
      else
      {
        SaveAnswer();
        this.questionIndex++;
        ShowQuestion();
        ResetAnswer();
      }
    }
    /// <summary>
    /// 保存答案
    /// </summary>
    private void SaveAnswer()
    {
      string answer = string.Empty;
      if (this.ckbA.Checked)
        answer += "A";
      if (this.ckbB.Checked)
        answer += "B";
      if (this.ckbC.Checked)
        answer += "C";
      if (this.ckbD.Checked)
        answer += "D";
      //将选择答案保存到Answer的SelectedAnswer中
      this.paper.Questions[questionIndex].QAnswer.SelectedAnswer = answer;
    }

    /// <summary>
    /// 重置答案（上一题和下一题事件中，如果已经选过答案，则显示以前显示的答案）
    /// </summary>
    private void ResetAnswer()
    {
      this.ckbA.Checked = paper.Questions[this.questionIndex].QAnswer.SelectedAnswer.Contains("A");
      this.ckbB.Checked = paper.Questions[this.questionIndex].QAnswer.SelectedAnswer.Contains("B");
      this.ckbC.Checked = paper.Questions[this.questionIndex].QAnswer.SelectedAnswer.Contains("C");
      this.ckbD.Checked = paper.Questions[this.questionIndex].QAnswer.SelectedAnswer.Contains("D");
    }
    //提交试卷
    private void btnSubmit_Click(object sender, EventArgs e)
    {
      SaveAnswer();//保存最后一次用户所选择答案
      //计算分数
      int score = this.paper.SubmitPaper();
      //当前面板显示成绩
      this.panelPaper.Visible = true;
      this.lblInfo.Text = $"您当前的成绩为：{score}分！";


    }
    //关闭窗体
    private void btnClose_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
