using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TeachDemo.Models
{
  /// <summary>
  /// 试题类
  /// </summary>
  class Paper
  {
    public Paper()
    {
      this.questions = new List<Question>();
    }
    private List<Question> questions;//学生提交的答案
    public List<Question> Questions//只读属性，试卷试题只读
    {
      get { return questions; }
    }

    #region 序列化读取存储试题
    /// <summary>
    /// 抽取试题
    /// </summary>
    //public void ExtractQuestions()
    //{
    //  using (FileStream fs = new FileStream("questions.txt", FileMode.Open))
    //  {
    //    using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
    //    {
    //      string content = sr.ReadToEnd();//一次性读取全部内容
    //      string[] qustionArray = content.Split('&');
    //      string[] question = null;//保存一道试题
    //      foreach (var item in qustionArray)
    //      {
    //        question = item.Trim().Split('\r');
    //        this.questions.Add(
    //          new Question
    //          {
    //            Title = question[0].Trim(),
    //            OptionA = question[1].Trim(),
    //            OptionB = question[2].Trim(),
    //            OptionC = question[3].Trim(),
    //            OptionD = question[4].Trim(),
    //            QAnswer = new Answer { RightAnswer = question[5].Trim() }
    //          });
    //      }
    //      SavePaper();
    //    }
    //  }
    //}
    ///// <summary>
    /// 文件序列化储存
    /// </summary>
    //private void SavePaper()
    //{
    //  using (FileStream fs = new FileStream("questions.obj", FileMode.Create))
    //  {
    //    BinaryFormatter bf = new BinaryFormatter();
    //    bf.Serialize(fs, this.questions);//将当前文本文件中读取的数据对象保存为集合对象，并以序列化方式存在
    //  }
    //} 
    #endregion

    /// <summary>
    /// 通过反序列化拿去文件
    /// </summary>
    public void ExtractQuestions() //项目初期用前面方法读取文件序列化存储，交给客户是序列化后的文件
    {
    //  //using (FileStream fs = new FileStream("questions.obj", FileMode.Open))
    //  //{
    //  //  BinaryFormatter bf = new BinaryFormatter();
    //  //  this.questions = (List<Question>)bf.Deserialize(fs);
    //  //}
      FileStream fs = new FileStream("questions.obj", FileMode.Open);
      BinaryFormatter bf = new BinaryFormatter();
      this.questions = (List<Question>)bf.Deserialize(fs);
      fs.Close();
    }

    /// <summary>
    /// 提交试卷计算分数
    /// </summary>
    /// <returns></returns>
    public int SubmitPaper()
    {
      int score = 0;
      foreach (Question item in this.questions)
      {
        if (item.QAnswer.SelectedAnswer == string.Empty) continue;
        if (item.QAnswer.RightAnswer.Equals(item.QAnswer.SelectedAnswer))
          score += 5;
      }
      return score;
    }

  }
}
