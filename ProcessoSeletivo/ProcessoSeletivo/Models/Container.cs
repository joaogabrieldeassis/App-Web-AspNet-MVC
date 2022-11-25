using ProcessoSeletivo.Models.Enus.EnunsDoContainer;
using System.ComponentModel.DataAnnotations;

namespace ProcessoSeletivo.Models
{
    public class Container : Entity
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z]{1,4}[0-9][0-9][0-9][0-9][0-9][0-9][0-9]")]
        public string NumerosDoConatiner{ get; set; }
        public Cliente Cliente { get; set; }
        public Categoria Categoria { get; set; }
        public Status Status { get; set; }
        public Tipo Tipo{ get; set; }
        public bool ValidarNumeros()
        {
            int armazenar = 0;
            foreach (var item in NumerosDoConatiner)
            {
                
                int[] array1 = new int[9] { 1,2,3,4,5,6,7,8,9};
                if (item == array1[item])
                {
                    armazenar++;
                }
            }
            if (armazenar == 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
