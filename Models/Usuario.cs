using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto29.Models{
    public class Usuario{
        
        private List<string> nomes = new List<string>();
        private List<int> idades = new List<int>();

        public Usuario(){}

        public void CadastrarUsuario(){

            string novoNome = string.Empty;
            int novaIdade = 0;

            Console.Write("Insira o nome: ");
            novoNome = Console.ReadLine();
            nomes.Add(novoNome);

            Console.Write($"Insira a idade de {novoNome}: ");
            novaIdade = Convert.ToInt32(Console.ReadLine());
            idades.Add(novaIdade);

            Console.WriteLine($"\nUsuário cadastrado!");

        }

        public void BuscarUsuario(){
            
            int i = 0;

            string nomeBuscado = string.Empty;

            Console.Write("Insira o nome que deseja buscar: ");
            nomeBuscado = Console.ReadLine();
            
            Console.WriteLine("");

            if(nomes.Any(x => x.ToUpper().Contains(nomeBuscado.ToUpper()))){ // verifica, por meio do parâmetro x, se o nome inserido para busca existe na lista
                foreach(string nome in nomes){ // criamos um "foreach que passará por cada nome da lista"
                    if(nome.Contains(nomeBuscado)){ // caso o nome da lista seja compatível com o solicitado, ele será exibido junta a sua idade

                        Console.Write($"Nome: {nome} | ");
                        Console.WriteLine($"Idade: {idades.ElementAt(i)}");
                        // Elementa.At irá exibir o elemento que está no índice que queremos
                        // Neste caso, o incrementador "i" recebe um valor que faz juz ao mesmo índice
                        // do nome. Se houver vários nomes iguais, todos serão exibidos com suas
                        // respectivas idades (coesão)
                    }
                    i++; 
                    // um contador deve ser incrementado para apontar qual o índice da idade que 
                    // queremos mostrar (ou seja, o índice da idade deve ser o mesmo do nome, 
                    // já que foram solicitados e armazenados ao mesmo tempo pelo CadastrarUsuario                   
                }
                Console.WriteLine("");
            }
            else{
                Console.WriteLine("Usuário não Encontrado!");
            }
        }

        public void ListarUsuarios(){
            Console.WriteLine(" ");

            if(nomes.Any()){ // verifica se há valores na lista
                foreach(string nome in nomes){
                    Console.WriteLine(nome);  
                }
            }
            else{
                Console.WriteLine("Não há usuários cadastrados");
            }
            Console.WriteLine(" ");
        }

        public void RemoverUsuario(){

            string nomeBuscado = string.Empty;
            string confimacao = string.Empty;
            int i = 0;

            Console.Write("Insira o usuário que deseja remover: ");
            nomeBuscado = Console.ReadLine();
            
            Console.WriteLine("");

            if(nomes.Any(x => x.ToUpper().Equals(nomeBuscado.ToUpper()))){ // verificando existência de nomes para remoção

                Console.Write($"Deseja remover {nomeBuscado} (S ou N)? ");
                confimacao = Console.ReadLine();

                if(confimacao.ToUpper().Equals("S")){ // verificando confirmação para remoção de usuário

                    foreach(string nome in nomes){ // o mesmo conceito de BuscarUsuario se repete
                        if(nome.Equals(nomeBuscado)){
                            // se o nome digitado para exclusão for compatível, ele  irá TENTAR
                            // remover a idade respectiva ao nome. Porém, caso o nome seja duplicado,
                            // o programa irá retornar uma excessão
                            try{
                                idades.RemoveAt(i); // RemoveAt é um método que removo o valor apontando seu índice
                            }
                            catch{
                                throw new Exception("Erro! Impossível remover mais de um usuário ao mesmo tempo.");
                            }
                        }
                        i++; 
                        // o incrementador desempenha o mesmo papel que exerce em BuscarUsuario:
                        // associar o índice da idade ao seu respectivo nome e criar coesão
                    }
                    nomes.Remove(nomeBuscado); // a remoção do nome deve ocorrer FORA do foreach
                    Console.WriteLine("Usuário removido!");
                }
                else{
                    Console.WriteLine("Operação cancelada!");
                }
                Console.WriteLine("");
            }
            else{
                Console.WriteLine("Usuário não Encontrado!");
            }
        }
    }
}