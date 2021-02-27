using CpmPedidos.Domain;
using CpmPedidos.Interface.Repositories;
using CpmPedidos.Repository.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmPedidos.Repository.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ApplicationDbContext context) : base(context)
        {

        }

        public dynamic Get(string order)
        {
            return Context.Produtos
                .Include(x => x.Categoria)
                .Where(x => x.Ativo)
                .OrderByName(order)
                .Select(x => new
                {
                    x.Nome,
                    x.Preco,
                    Categoria = x.Categoria.Nome,
                    Imagens = x.Imagens.Select(x => new
                    {
                        x.Id,
                        x.Nome,
                        x.NomeArquivo
                    })
                });
        }


        public dynamic Search(string text, int page, string order)
        {
            var queryProduto = Context.Produtos
                .Include(x => x.Categoria)
                .Where(x => x.Ativo && x.Nome.ToUpper().Contains(text.ToUpper()) || x.Descricao.ToUpper().Contains(text.ToUpper()))
                .OrderByName(order)
                .Skip(TamanhoPagina * (page - 1)) //Conta para achar o primeiro elemento da página
                .Take(TamanhoPagina)
                .Select(x => new
                {
                    x.Nome,
                    x.Preco,
                    Categoria = x.Categoria.Nome,
                    x.Imagens
                });

            var produtos = queryProduto.ToList();

            var quantProdutos = Context.Produtos
                .Where(x => x.Ativo && x.Nome.ToUpper().Contains(text.ToUpper()) || x.Descricao.ToUpper().Contains(text.ToUpper()))
                .Count();

            var quantPaginas = (quantProdutos / TamanhoPagina);

            if (quantPaginas < 1)
            {
                quantPaginas = 1;
            }

            return new { produtos, quantPaginas };
        }

        public dynamic Detail(int id)
        {
            return Context.Produtos
                .Include(x => x.Imagens)
                .Include(x => x.Categoria)
                .Where(x => x.Ativo && x.Id == id)
                .Select(x => new
                {
                    x.Id,
                    x.Nome,
                    x.Codigo,
                    x.Descricao,
                    x.Preco,
                    Categoria = new
                    {
                        x.Categoria.Id,
                        x.Categoria.Nome
                    },
                    Imagens = x.Imagens.Select(x => new
                    {
                        x.Id,
                        x.Nome,
                        x.NomeArquivo
                    })
                })
                .FirstOrDefault();
        }

        public dynamic Images(int id)
        {
            return Context.Produtos
                .Include(x => x.Imagens)
                .Where(x => x.Ativo && x.Id == id)
                .SelectMany(x => x.Imagens, (produto, imagem) => new
                {
                    Produto = new
                    {
                        produto.Id,
                        produto.Nome
                    },
                    imagem.Id,
                    imagem.Nome,
                    imagem.NomeArquivo
                })
                .FirstOrDefault();
        }


    }
}

