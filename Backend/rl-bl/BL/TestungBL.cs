using System;
using rl_contract.Models;

namespace rl_bl
{
    public class TestungBL
    {
        public TestungBL()
        {

        }

        public void calculateScore(Testung _testung)
        {
            _testung.Chapters.ForEach(chapter =>
            {
                var scoreForChapter = -1;
                var index = 1;
                chapter.Questions.ForEach(question =>
                {
                    if (question.Type == "radio")
                    {
                        int qScore = 0;
                        Int32.TryParse(question.Value, out qScore);
                        scoreForChapter += qScore;
                        index++;
                    }
                });
                chapter.Score = (scoreForChapter >= 0) ? scoreForChapter / index: -1;
            });
        }
    }
}
