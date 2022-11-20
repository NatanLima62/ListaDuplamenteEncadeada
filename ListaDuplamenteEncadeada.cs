using System.Security.Cryptography.X509Certificates;

namespace ListaDuplamenteEncadeada;

public class ListaDuplamenteEncadeada
{
    /* Operacoes
     * Inserir no inicio
     * Retirar do inicio
     * Inserir no Meio
     * Retirar do Meio
     * Inserir no final
     * Retirar do final
     */
    public static void Main(string[] args)
    {
        ListaDupla listaDupla = new ListaDupla();
        Console.WriteLine(listaDupla);

        for (int i = 0; i < 6; i++)
        {
            listaDupla.InserirNoInicio("" + (char) (i + 97));
            Console.WriteLine(listaDupla.ToString());
        }
        
        listaDupla.InserirNoMeio(1, "X");
        Console.WriteLine(listaDupla.ToString());
        
        listaDupla.RetirarMeio(4);
        Console.WriteLine("Removendo o C (P4)");
        Console.WriteLine(listaDupla.ToString());
    }

    public class No
    {
        public string Info;
        public No? Proximo;
        public No? Anterior;
    }

    public class ListaDupla
    {
        public No? Inicio;
        public No? Fim;
        public int Tamanho;

        public void InserirNoInicio(string info)
        {
            No no = new No();
            no.Info = info;
            no.Anterior = null;
            no.Proximo = Inicio;

            if (Inicio != null)
            {
                Inicio.Anterior = no;
            }

            Inicio = no;

            if (Tamanho == 0)
            {
                Fim = Inicio;
            }

            Tamanho++;
        }

        public string RetirarDoInicio()
        {
            if (Inicio == null)
            {
                return null;
            }

            var auxiliar = Inicio.Info;
            Inicio = Inicio.Proximo;

            if (Inicio != null)
            {
                Inicio.Anterior = null;
            }
            else
            {
                Fim = null;
            }

            Tamanho--;
            return auxiliar;
        }

        public void InserirFim(string info)
        {
            No no = new No();
            no.Info = info;
            no.Proximo = null;
            no.Anterior = Fim;

            if (Fim != null)
            {
                Fim.Proximo = no;
            }

            Fim = no;

            if (Tamanho == 0)
            {
                Inicio = Fim;
            }

            Tamanho++;
        }

        public string RetirarFim()
        {
            if (Fim == null)
            {
                return null;
            }

            var auxiliar = Fim.Info;

            Fim = Fim.Anterior;

            if (Fim != null)
            {
                Fim.Proximo = null;
            }
            else
            {
                Inicio = null;
            }

            Tamanho--;

            return auxiliar;
        }

        public void InserirNoMeio(int indice, string info)
        {
            if (indice <= 0)
            {
                InserirNoInicio(info);
            }
            else if (indice >= Tamanho)
            {
                InserirFim(info);
            }
            else
            {
                No local = Inicio;

                for (int i = 0; i < indice - 1; i++)
                {
                    local = local.Proximo;
                }

                No no = new No();
                no.Info = info;
                no.Anterior = local;
                no.Proximo = local.Proximo;
                local.Proximo = no;
                no.Proximo.Anterior = no;
                Tamanho++;
            }
        }

        public string RetirarMeio(int indice)
        {
            if (indice < 0 || indice >= Tamanho || Inicio == null)
            {
                return null;
            }
            else if (indice == 0)
            {
                return RetirarDoInicio();
            }
            else if (indice == Tamanho - 1)
            {
                return RetirarFim();
            }

            No local = Inicio;

            for (int i = 0; i < indice; i++)
            {
                local = local.Proximo;
            }

            if (local.Anterior != null)
            {
                local.Anterior.Proximo = local.Proximo;
            }

            if (local.Proximo != null)
            {
                local.Proximo.Anterior = local.Anterior;
            }

            Tamanho--;

            return local.Info;
        }

        public string ToString()
        {
            string str = $" ({Tamanho}) ";
            No? local = Inicio;
        
            while (local != null)
            {
                str += local.Info + " ";
                local = local.Proximo;
            }
        
            return str;
        }
    }
}