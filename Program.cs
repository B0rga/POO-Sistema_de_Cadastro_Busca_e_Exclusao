

using Projeto29.Models;

Usuario usuario = new Usuario();
bool menu = true;

while(menu == true){
    Console.Clear();
    Console.WriteLine("1 - Cadastrar usuário");
    Console.WriteLine("2 - Buscar usuário");
    Console.WriteLine("3 - Remover usuário");
    Console.WriteLine("4 - Listar usuários");
    Console.WriteLine("5 - Sair");
    Console.Write("\nInsira uma opção: ");

    switch(Console.ReadLine()){
        case "1":
            usuario.CadastrarUsuario();
            break;
        case "2":
            usuario.BuscarUsuario();
            break;
        case "3":
            usuario.RemoverUsuario();
            break;
        case "4":
            usuario.ListarUsuarios();
            break;
        case "5":
            menu = false;
            break;
        default:
            Console.WriteLine("Opção inválida!");
            break;
    }
    Console.Write("Qualquer tecla para continuar: ");
    Console.ReadLine();
}
Console.WriteLine("Programa encerrado\n");

