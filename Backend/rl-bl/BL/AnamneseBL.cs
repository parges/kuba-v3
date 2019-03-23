﻿using System;
using rl_contract.Models;

namespace rl_bl
{
    public class AnamneseBL
    {
        public AnamneseBL()
        {

        }

        public void calculateCountPositivAnswers(Anamnese _item)
        {
            var countOfPositivAnswers = -1;
            var index = 1;
            _item.Chapters.ForEach(chapter =>
            {
                chapter.Questions.ForEach(question =>
                {
                    if (question.Type.IndexOf("radioYesNo", StringComparison.Ordinal) >= 0 )
                    {
                        if (question.Value == "1")
                        {
                            countOfPositivAnswers++;
                        }
                        index++;
                    }
                });
            });
            _item.CountOfPositivAnswers = (countOfPositivAnswers >= 0) ? countOfPositivAnswers / index : -1;
        }
    }
}
