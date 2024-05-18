using System.ComponentModel.DataAnnotations;

namespace Guestbook.Models.Entries;

public class CreateEntryViewModel
{
  [Display(Name = "Inhalt")]
  [Required(ErrorMessage = "Bitte schreibe etwas.")]
  public required string Content { get; init; }
}
