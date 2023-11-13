using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caVentilador
{
    internal class Stack<T>
    {
        public Noh<T> Head { get; set; }
        public int Count { get; private set; }

        public Stack()
        {
            this.Head = new Noh<T>(default(T));
            this.Head.anterior = null;
            this.Head.proximo = null;
            this.Count = 0;
        }

        public void Push(T info)
        {
            Noh<T> novoNoh = new Noh<T>(info);

            if (this.Head.proximo == null)
            {
                this.Head.proximo = novoNoh;
                this.Head.anterior = novoNoh;
            }
            else
            {
                novoNoh.anterior = this.Head.anterior;
                this.Head.anterior.proximo = novoNoh;
                this.Head.anterior = novoNoh;
            }

            Count++;
        }

        public T Pop()
        {
            if (Count > 0)
            {
                T poppedValue = Head.anterior.info;
                Head.anterior = Head.anterior.anterior;

                if (Head.anterior != null)
                {
                    Head.anterior.proximo = null;
                }
                else
                {
                    Head.proximo = null;
                }

                Count--;

                return poppedValue;
            }
            else
            {
                throw new InvalidOperationException("Stack is empty. Cannot pop.");
            }
        }
        public void TrocaDePeca(T velha, T nova)
        {
            Stack<Noh<T>> pilhaRemovidos = new Stack<Noh<T>>();


            Noh<T> nohAtual = Head.proximo;
            while (nohAtual != null)
            {
                if (nohAtual.info.Equals(velha))
                {

                    pilhaRemovidos.Push(nohAtual);


                    nohAtual.anterior.proximo = nohAtual.proximo;
                    if (nohAtual.proximo != null)
                    {
                        nohAtual.proximo.anterior = nohAtual.anterior;
                    }

                    break; 
                }

                nohAtual = nohAtual.proximo;
            }

            while (pilhaRemovidos.Count > 0)
            {
                Noh<T> nohRemovido = pilhaRemovidos.Pop();

                nohRemovido.proximo = Head.proximo;
                nohRemovido.anterior = Head;
                if (Head.proximo != null)
                {
                    Head.proximo.anterior = nohRemovido;
                }
                Head.proximo = nohRemovido;
            }
        }


    }
}
