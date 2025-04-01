using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities;

public partial class Question
{
    public int QuestionId { get; set; }

    public string Title { get; set; } = null!;

    public string Answer { get; set; } = null!;

    public string Type { get; set; } = null!;
}
