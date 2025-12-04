using System.Data;
using Dapper;
using Library_Mvc.Interfaces;
using Library_Mvc.Models.DtoModels;

namespace Library_Mvc.Repositories;

public class BookRepository(IDbConnection connection) : IBookRepository
{
    public async Task<IEnumerable<BookCardDto>> GetAllAsync()
    {
        var sql = """
                  select 
                    b.id,
                    b.name,
                    b.author,
                    b.ref_img as refImg,
                    case when bb.id is not null 
                        then 'Выдана' 
                        else 'В наличий' 
                    end as status
                  from books b
                  left join borrowed_books bb on b.id = bb.book_id 
                  and bb.date_returned is null
                  order by b.created_at desc;
                  """;
        return await connection.QueryAsync<BookCardDto>(sql);
    }

    public async Task<BookDetailDto?> GetByIdAsync(long id)
    {
        var sql = """
                  select 
                    b.id,
                    b.name,
                    b.author,
                    b.ref_img as refImg,
                    b.year_of_release as yearOfRelease,
                    b.description,
                    b.created_at as createdAt,
                    c.name as categoryName,
                    case when bb.id is not null then 'Выдана' else 'В наличий' end as status
                  from books b
                  left join categories c on b.category_id = c.id
                  left join borrowed_books bb on b.id = bb.book_id and bb.date_returned is null where b.id = @id;
                  """;
        return await connection.QuerySingleOrDefaultAsync<BookDetailDto>(sql, new { id });
    }

    public async Task<long> CreateAsync(BookCreateDto bookCreateDto)
    {
        var sql = """
                  insert into books(name, author, ref_img, year_of_release, description, category_id)
                  values (@name, @author, @refImg, @yearOfRelease, @description, @categoryId)
                  returning id;
                  """;
        return await connection.ExecuteScalarAsync<long>(sql, bookCreateDto);
    }

    public async Task UpdateAsync(long id, BookCreateDto bookCreateDto)
    {
        var sql = """
                  update books set
                  name = @name,
                  author = @author,
                  ref_img = @refImg,
                  year_of_release = @yearOfRelease,
                  description = @description,
                  category_id = @categoryId
                  where id = @id;
                  """;
        await connection.ExecuteAsync(sql, new
        {
            bookCreateDto.Name,
            bookCreateDto.Author,
            bookCreateDto.RefImg,
            bookCreateDto.YearOfRelease,
            bookCreateDto.Description,
            bookCreateDto.CategoryId
        });
    }

    public async Task DeleteAsync(long id)
    {
        var sql = "delete from books where id = @id";
        await connection.ExecuteAsync(sql, new { id });
    }
}