using Microsoft.VisualBasic;

namespace ProjetoTransacoesImobiliarias.Models;

public class Property
{
    public int IdProperty { get; set;}
    public string Adress { get; set;}
    public PropertyType type { get; set;}

    public Property(){
        
    }

}