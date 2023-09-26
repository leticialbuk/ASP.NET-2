using System.ComponentModel.DataAnnotations;

namespace Blog_2.ViewModels
{
    public class EditorCategoryViewModel
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(40, MinimumLength = 6, ErrorMessage = "Este campo deve conter entre 6 e 40 caracteres")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "O slug é obrigatório")]
        public string Slug { get; set; }
    }
}
