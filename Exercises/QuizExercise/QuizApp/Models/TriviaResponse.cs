using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Models;

public class TriviaResponse
{
    public int response_code { get; set; }
    public List<TriviaQuestion> results { get; set; } = new List<TriviaQuestion>();
}