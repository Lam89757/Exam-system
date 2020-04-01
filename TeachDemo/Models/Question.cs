using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachDemo
{
  /// <summary>
  /// 试题类
  /// </summary>
  [Serializable]
  class Question
  {
    public Question()
    {
      QAnswer = new Answer();
    }
    public int QuestionId { get; set; }
    public string Title { get; set; }
    public string OptionA { get; set; }
    public string OptionB { get; set; }
    public string OptionC { get; set; }
    public string OptionD { get; set; }

    public Answer QAnswer { get; set; }//答案

  }
}
