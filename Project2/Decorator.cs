using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    public class Program
    {
        public static void Main()
        {
            Texto texto = new Texto("Exemplo de texto");
            NegritoTexto negrito = new NegritoTexto(texto);
            ItalicoTexto italico = new ItalicoTexto(negrito);
            string textoDecorado = italico.GetTexto();
            Console.WriteLine(textoDecorado);
        }
    }

    public interface ITexto
    {
        string GetTexto();
    }

    public class Texto : ITexto
    {
        private string texto;

        public Texto(string texto)
        {
            this.texto = texto;
        }

        public string GetTexto()
        {
            return texto;
        }
    }

    public abstract class DecoratorTexto : ITexto
    {
        protected ITexto texto;

        public DecoratorTexto(ITexto texto)
        {
            this.texto = texto;
        }

        public virtual string GetTexto()
        {
            return texto.GetTexto();
        }
    }

    public class NegritoTexto : DecoratorTexto
    {
        public NegritoTexto(ITexto texto) : base(texto)
        {
        }

        public override string GetTexto()
        {
            return "<b>" + base.GetTexto() + "</b>";
        }
    }

    public class ItalicoTexto : DecoratorTexto
    {
        public ItalicoTexto(ITexto texto) : base(texto)
        {
        }

        public override string GetTexto()
        {
            return "<i>" + base.GetTexto() + "</i>";
        }
    }

}
