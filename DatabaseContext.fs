namespace DotnetTest.DatabaseContext

open Microsoft.EntityFrameworkCore
open DotnetTest.Domain

type DatabaseContext =
    inherit DbContext

    new() = {inherit DbContext()}
    new(options: DbContextOptions<DatabaseContext>) = {inherit DbContext(options)}

    override this.OnModelCreating(mb:ModelBuilder) =
        ()


