using AS.ProjetoCompleto.Application.Interfaces;
using System;
using System.Collections.Generic;
using AS.ProjetoCompleto.Application.ViewModels;
using AS.ProjetoCompleto.Dominio.Interfaces;
using AS.ProjetoCompleto.Infra.Data.Repository;
using AutoMapper;
using AS.ProjetoCompleto.Dominio.Models;

namespace AS.ProjetoCompleto.Application.Services
{
    //será chamado pela camada de apresentação, pois ela 
    //não enxerga a camada de Domínio, somente a camada de Aplicação.
    public class ClienteAppService : IClienteAppService
    {
        //consultar repositório somente leitura
        private readonly IClienteRepository _clienteRepository;

        public ClienteAppService()
        {
            _clienteRepository = new ClienteRepository();
        }

        public IEnumerable<ClienteViewModel> ObterAtivos()
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_clienteRepository.ObterAtivos());
        }

        public ClienteViewModel ObterPorCpf(string cpf)
        {
            return Mapper.Map<ClienteViewModel>(_clienteRepository.ObterPorCpf(cpf));
        }

        public ClienteViewModel ObterPorEmail(string email)
        {
            return Mapper.Map<ClienteViewModel>(_clienteRepository.ObterPorEmail(email));
        }

        public ClienteViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<ClienteViewModel>(_clienteRepository.ObterPorId(id));
        }

        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_clienteRepository.ObterTodos());
        }

        public ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            var cliente = Mapper.Map<Cliente>(clienteEnderecoViewModel.Cliente);
            var endereco = Mapper.Map<Endereco>(clienteEnderecoViewModel.Endereco);

            //cliente sempre entre ativo
            cliente.Ativar();
            cliente.AdicionarEndereco(endereco);

            _clienteRepository.Adicionar(cliente);

            return clienteEnderecoViewModel;
        }

        public ClienteViewModel Atualizar(ClienteViewModel clienteViewModel)
        {
            var cliente = Mapper.Map<Cliente>(clienteViewModel);

            _clienteRepository.Atualizar(cliente);

            return clienteViewModel;
        }

        public void Remover(Guid id)
        {
            _clienteRepository.Remover(id);
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
        }

    }
}
