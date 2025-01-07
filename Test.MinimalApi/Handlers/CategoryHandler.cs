using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Test.Core.Handlers;
using Test.Core.Models;
using Test.Core.Requests.Categories;
using Test.Core.Responses;
using Test.MinimalApi.Data;

namespace Test.MinimalApi.Handlers;

public class CategoryHandler(TestDbContext context) : ICategoryHandler
{
    public async Task<Response<Category?>> PostCategoryAsync(CreateCategoryRequest request)
    {
        try
        {
            var category = new Category
            {
                Title = request.Title,
                Description = request.Description,
            };
            
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
            
            return new Response<Category?>(category, 201, "Categoria criada com sucesso!");
        }
        catch (ArgumentNullException)
        {
            // Exceção para dados nulos
            return new Response<Category?>(null, 400, "Requisição inválida.");
        }
        catch (DbUpdateException)
        {
            // Erro ao tentar salvar no banco de dados
            return new Response<Category?>(null, 500, "Erro ao salvar no banco de dados.");
        }
        catch (InvalidOperationException)
        {
            // Operação inválida
            return new Response<Category?>(null, 500, "Erro interno no servidor.");
        }
        catch (SqlException)
        {
            // Erro específico de SQL (se usar SQL Server)
            return new Response<Category?>(null, 500, "Erro no banco de dados.");
        }
        catch (Exception)
        {
            // Exceção genérica para capturar qualquer erro inesperado
            return new Response<Category?>(null, 500, "Erro desconhecido.");
        }
    }

    public async Task<Response<Category?>> UpdateCategoryAsync(UpdateCategoryRequest request)
    {
        try
        {
            var category = await context
                .Categories
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

            if (category == null)
                return new Response<Category?>(null, 404, "Categoria nao encontrada.");
            
            category.Title = request.Title;
            category.Description = request.Description;
            
            context.Categories.Update(category);
            await context.SaveChangesAsync();
            
            return new Response<Category?>(category, 200, "Categoria atualizada com sucesso!");
        }
        catch (ArgumentNullException)
        {
            // Exceção para dados nulos
            return new Response<Category?>(null, 400, "Requisição inválida.");
        }
        catch (DbUpdateException)
        {
            // Erro ao tentar salvar no banco de dados
            return new Response<Category?>(null, 500, "Erro ao salvar no banco de dados.");
        }
        catch (InvalidOperationException)
        {
            // Operação inválida
            return new Response<Category?>(null, 500, "Erro interno no servidor.");
        }
        catch (SqlException)
        {
            // Erro específico de SQL (se usar SQL Server)
            return new Response<Category?>(null, 500, "Erro no banco de dados.");
        }
        catch (Exception)
        {
            // Exceção genérica para capturar qualquer erro inesperado
            return new Response<Category?>(null, 500, "Erro desconhecido.");
        }
    }

    public async Task<Response<Category?>> DeleteCategoryAsync(DeleteCategoryRequest request)
    {
        try
        {
            var category = await context
                .Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);
            
            if (category == null)
                return new Response<Category?>(null, 404, "Categoria nao encontrada.");
            
            context.Categories.Remove(category);
            await context.SaveChangesAsync();
            
            return new Response<Category?>(category, 200, "Categoria deletada com sucesso!");
        }
        catch (ArgumentNullException)
        {
            // Exceção para dados nulos
            return new Response<Category?>(null, 400, "Requisição inválida.");
        }
        catch (DbUpdateException)
        {
            // Erro ao tentar salvar no banco de dados
            return new Response<Category?>(null, 500, "Erro ao salvar no banco de dados.");
        }
        catch (InvalidOperationException)
        {
            // Operação inválida
            return new Response<Category?>(null, 500, "Erro interno no servidor.");
        }
        catch (SqlException)
        {
            // Erro específico de SQL (se usar SQL Server)
            return new Response<Category?>(null, 500, "Erro no banco de dados.");
        }
        catch (Exception)
        {
            // Exceção genérica para capturar qualquer erro inesperado
            return new Response<Category?>(null, 500, "Erro desconhecido.");
        }
    }

    public async Task<Response<Category?>> GetByIdCategoryAsync(GetByIdCategoryRequest request)
    {
        try
        {
            var category = await context
                .Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);
            
            if (category == null)
                return new Response<Category?>(null, 404, "Categoria nao encontrada.");
            
            return new Response<Category?>(category);
        }
        catch (ArgumentNullException)
        {
            // Exceção para dados nulos
            return new Response<Category?>(null, 400, "Requisição inválida.");
        }
        catch (DbUpdateException)
        {
            // Erro ao tentar salvar no banco de dados
            return new Response<Category?>(null, 500, "Erro ao salvar no banco de dados.");
        }
        catch (InvalidOperationException)
        {
            // Operação inválida
            return new Response<Category?>(null, 500, "Erro interno no servidor.");
        }
        catch (SqlException)
        {
            // Erro específico de SQL (se usar SQL Server)
            return new Response<Category?>(null, 500, "Erro no banco de dados.");
        }
        catch (Exception)
        {
            // Exceção genérica para capturar qualquer erro inesperado
            return new Response<Category?>(null, 500, "Erro desconhecido.");
        }
    }

    public async Task<Response<List<Category>?>> GetAllCategoriesAsync(GetAllCategoriesRequest request)
    {
        try
        {
            var categories = await context
                .Categories
                .AsNoTracking()
                .Where(x => x.UserId == request.UserId).ToListAsync();

            if (categories.Count == 0)
                return new Response<List<Category>?>(null, 404, "Nenhuma categoria encontrada.");

            return new Response<List<Category>?>(categories);
        }
        catch (ArgumentNullException)
        {
            // Exceção para dados nulos
            return new Response<List<Category>?>(null, 400, "Requisição inválida.");
        }
        catch (DbUpdateException)
        {
            // Erro ao tentar salvar no banco de dados
            return new Response<List<Category>?>(null, 500, "Erro ao salvar no banco de dados.");
        }
        catch (InvalidOperationException)
        {
            // Operação inválida
            return new Response<List<Category>?>(null, 500, "Erro interno no servidor.");
        }
        catch (SqlException)
        {
            // Erro específico de SQL (se usar SQL Server)
            return new Response<List<Category>?>(null, 500, "Erro no banco de dados.");
        }
        catch (Exception)
        {
            // Exceção genérica para capturar qualquer erro inesperado
            return new Response<List<Category>?>(null, 500, "Erro desconhecido.");
        }
    }
}