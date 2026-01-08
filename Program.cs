using System;
using System.Collections.Generic;
using ClinicaVet.Models;
using ClinicaVet.Data;
using ClinicaVet.Repositories;

class Program
{
    static void Main()
    {
        using var context = new ClinicaVetContext();
        context.Database.EnsureCreated();

        var clienteRepo = new ClienteRepository(context);
        var consultaRepo = new ConsultaRepository(context);

        while (true)
        {
            Console.Clear();
            Console.WriteLine("MENU PRINCIPAL");
            Console.WriteLine(
                "1 - CADASTRAR NOVO CLIENTE\n" +
                "2 - ATUALIZAR CLIENTE\n" +
                "3 - APAGAR CLIENTE\n" +
                "4 - LISTAR CLIENTES E CONSULTAS\n" +
                "5 - APAGAR CONSULTA\n" +
                "6 - SAIR"
            );

            Console.WriteLine("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            Console.WriteLine($"Confirma a opção {opcao}? (SIM ou NÃO): ");
            string confirmacao = Console.ReadLine().ToUpper();

            if (confirmacao == "SIM")
            {
                if (opcao == "1")
                {
                    Console.Clear();
                    Console.WriteLine("CADASTRO DE CLIENTE");

                    Cliente cliente = new Cliente();

                    Console.WriteLine("Nome do animal: ");
                    cliente.NomeAnimal = Console.ReadLine();

                    Console.WriteLine("Idade do animal: ");
                    cliente.Idade = Console.ReadLine();

                    Console.WriteLine("Sexo do animal: ");
                    cliente.Sexo = Console.ReadLine();

                    Console.WriteLine("Espécie: ");
                    cliente.Especie = Console.ReadLine();

                    Console.WriteLine("Raça: ");
                    cliente.Raca = Console.ReadLine();

                    Console.WriteLine("Porte: ");
                    cliente.Porte = Console.ReadLine();

                    Console.WriteLine("Nome do dono: ");
                    cliente.NomeDono = Console.ReadLine();

                    Console.WriteLine("Telefone: ");
                    cliente.Telefone = Console.ReadLine();

                    Console.WriteLine("Motivo da consulta: ");
                    cliente.MotivoConsulta = Console.ReadLine();

                    clienteRepo.Adicionar(cliente);

                    Console.WriteLine("CADASTRO CONCLUÍDO");
                    Console.WriteLine("Pressione ENTER para voltar ao menu.");
                    Console.ReadLine();
                }

                else if (opcao == "2")
                {
                    Console.Clear();
                    Console.WriteLine("ATUALIZAR CLIENTE");

                    var clientes = clienteRepo.Listar();

                    if (clientes.Count == 0)
                    {
                        Console.WriteLine("Nenhum cliente cadastrado. Pressione ENTER para voltar ao menu.");
                        Console.ReadLine();
                        continue;
                    }

                    else
                    {
                        Console.WriteLine("Selecione o cliente: ");

                        for (int i = 0; i < clientes.Count; i++)
                        {
                            Console.WriteLine($"{i + 1} - {clientes[i].NomeAnimal}");
                        }
                    }

                    Console.WriteLine("Digite o número do cliente: ");
                    int escolha = int.Parse(Console.ReadLine());

                    var clienteSelecionado = clientes[escolha - 1];

                    Consulta consulta = new Consulta();
                    consulta.ClienteId = clienteSelecionado.Id;

                    Console.WriteLine("Exames realizados: ");
                    consulta.Exames = Console.ReadLine();

                    Console.WriteLine("Diagnóstico ");
                    consulta.Diagnostico = Console.ReadLine();

                    Console.WriteLine("Medicações prescritas: ");
                    consulta.Medicacoes = Console.ReadLine();

                    Console.WriteLine("Conduta: ");
                    consulta.Conduta = Console.ReadLine();

                    Console.WriteLine("Houve internação? (SIM OU NÃO) ");
                    string internacao = Console.ReadLine().ToUpper();

                    if (internacao == "SIM")
                    {
                        consulta.HouveInternacao = true;

                        Console.WriteLine("Quantos dias de internação?");
                        consulta.DiasInternacao = Console.ReadLine();

                        Console.WriteLine("Procedimentos realizados: ");
                        consulta.ProcedimentosInternacao = Console.ReadLine();
                    }

                    else
                    {
                        consulta.HouveInternacao = false;
                        Console.WriteLine("Sem internação registrada");
                    }

                    consultaRepo.Adicionar(consulta);

                    Console.WriteLine("ATUALIZAÇÃO CONCLUÍDA");
                }

                else if (opcao == "3")
                {
                    Console.Clear();
                    Console.WriteLine("APAGAR CLIENTE");

                    var clientes = clienteRepo.Listar();

                    if (clientes.Count == 0)
                    {
                        Console.WriteLine("Nenhum cliente cadastrado. Pressione ENTER para voltar ao menu.");
                        Console.ReadLine();
                        continue;
                    }

                    Console.WriteLine("Selecione o cliente que deseja apagar: ");

                    for (int i = 0; i < clientes.Count; i++)
                    {
                        Console.WriteLine($"{i + 1} = {clientes[i].NomeAnimal} | Dono: {clientes[i].NomeDono}");
                    }

                    Console.WriteLine("Digite o número do cliente: ");
                    int escolha = int.Parse(Console.ReadLine());

                    Cliente clienteSelecionado = clientes[escolha - 1];

                    Console.WriteLine($"Tem certeza que deseja apagar o cliente {clienteSelecionado.NomeAnimal}?");
                    string confirmarExclusao = Console.ReadLine().ToUpper();

                    if (confirmarExclusao == "SIM")
                    {
                        clienteRepo.Remover(clienteSelecionado.Id);
                        Console.WriteLine("Cliente removido com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Exclusão cancelada");
                    }

                    Console.WriteLine("Pressione ENTER para voltar ao menu.");
                    Console.ReadLine();
                }

                else if (opcao == "4")
                {
                    Console.Clear();
                    Console.WriteLine("LISTA DE CLIENTES E CONSULTAS");

                    var clientes = clienteRepo.Listar();

                    if (clientes.Count == 0)
                    {
                        Console.WriteLine("Nenhum cliente cadastrado. Pressione ENTER para voltar ao menu.");
                        Console.ReadLine();
                        continue;
                    }

                    for (int i = 0; i < clientes.Count; i++)
                    {
                        Cliente cliente = clientes[i];

                        Console.WriteLine($"Cliente {i + 1}");
                        Console.WriteLine($"Animal: {cliente.NomeAnimal}");
                        Console.WriteLine($"Espécie: {cliente.Especie}");
                        Console.WriteLine($"Raça: {cliente.Raca}");
                        Console.WriteLine($"Dono: {cliente.NomeDono}");
                        Console.WriteLine($"Telefone: {cliente.Telefone}");

                        Console.WriteLine("Consultas: ");

                        if (cliente.Consultas.Count == 0)
                        {
                            Console.WriteLine("Nenhuma consulta registrada");
                        }
                        else
                        {
                            for (int j = 0; j < cliente.Consultas.Count; j++)
                            {
                                Consulta consulta = cliente.Consultas[j];

                                Console.WriteLine($"Consulta {j + 1}");
                                Console.WriteLine($"Diagnóstico: {consulta.Diagnostico}");
                                Console.WriteLine($"Exames: {consulta.Exames}");
                                Console.WriteLine($"Medicações: {consulta.Medicacoes}");
                                Console.WriteLine($"Conduta: {consulta.Conduta}");

                                if (consulta.HouveInternacao)
                                {
                                    Console.WriteLine($"Internação: SIM");
                                    Console.WriteLine($"Dias: {consulta.DiasInternacao}");
                                    Console.WriteLine($"Procedimentos: {consulta.ProcedimentosInternacao}");
                                }
                                else
                                {
                                    Console.WriteLine($"Internação: NÃO");
                                }
                            }
                        }
                    }

                    Console.WriteLine("Pressione ENTER para voltar ao menu.");
                    Console.ReadLine();
                }

                else if (opcao == "5")
                {
                    Console.Clear();
                    Console.WriteLine("APAGAR CONSULTA");

                    var clientes = clienteRepo.Listar();

                    if (clientes.Count == 0)
                    {
                        Console.WriteLine("Nenhuma cliente cadastrado. Pressione ENTER para voltar ao menu.");
                        Console.ReadLine();
                        continue;
                    }

                    Console.WriteLine("Selecione o cliente: ");

                    for (int i = 0; i < clientes.Count; i++)
                    {
                        Console.WriteLine($"{i + 1} - {clientes[i].NomeAnimal}");
                    }

                    Console.WriteLine("Digite o número do cliente: ");
                    int escolhaCliente = int.Parse(Console.ReadLine());

                    var clienteSelecionado = clientes[escolhaCliente - 1];

                    if (clienteSelecionado.Consultas.Count == 0)
                    {
                        Console.WriteLine("Esse cliente não possui consultas cadastradas. Aperte ENTER para voltar ao menu.");
                        Console.ReadLine();
                        continue;
                    }

                    Console.WriteLine($"Consultas de {clienteSelecionado.NomeAnimal}: ");

                    for (int i = 0; i < clienteSelecionado.Consultas.Count; i++)
                    {
                        Console.WriteLine($"{i + 1} - {clienteSelecionado.Consultas[i].Diagnostico}");
                    }

                    Console.WriteLine("Digite o número da consulta que deseja apagar: ");
                    int escolhaConsulta = int.Parse(Console.ReadLine());

                    var consultaSelecionada = clienteSelecionado.Consultas[escolhaConsulta - 1];

                    Console.WriteLine("Tem certeza que deseja apagar essa consulta?");
                    string confirmar = Console.ReadLine().ToUpper();

                    if (confirmar == "SIM")
                    {
                        consultaRepo.Remover(consultaSelecionada.Id);
                        Console.WriteLine("Consulta apagada com sucesso");
                    }
                    else
                    {
                        Console.WriteLine("Exclusão cancelada");
                    }

                    Console.WriteLine("Pressione ENTER para voltar ao menu.");
                    Console.ReadLine();
                }

                else if (opcao == "6")
                {
                    Console.WriteLine("Encerrando o sistema...");
                    break;
                }
            }
            else
            {
                Console.WriteLine("Opção cancelada");
            }
        }
    }
}
