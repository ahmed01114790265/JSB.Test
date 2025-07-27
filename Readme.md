project dependencies 
 # Presentation depends on ==> Application , Contracts
 # Application depends on ==> Contracts,Domain 

 steps for adding EntityFramework
 # install the following packages :-
  ## Microsoft.EntityFrameworkCore
  ## Microsoft.EntityFrameworkCore.SqlServer
  ## Microsoft.EntityFrameworkCore.Tools
# create ProjectDbContext class and make it inherit from DbContext class 
# add DbSets for your model , ex: DbSet<Book> Books
# add DbSets for your model , ex: DbSet<Category> Categories
# in ProjectDbContext class ovveride onConfiguring method and using passed options configure the dbContext using DbContextOptionsBuilder
# object , 
  ## base.OnConfiguring(optionsBuilder);
  ##  ptionsBuilder.UseSqlServer(Configuration.GetConnectionString("cs"));
# or you configure it during register dbContext in IOC container in program.cs

# in ProjectDbContext class ovveride onModelCreating method and within it configure entities