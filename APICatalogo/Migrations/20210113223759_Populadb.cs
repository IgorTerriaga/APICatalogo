using Microsoft.EntityFrameworkCore.Migrations;

namespace APICatalogo.Migrations
{
    public partial class Populadb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert Into categoria (Nome, ImagemUrl) " +
                "VALUES ('Bebidas', 'http://www.macoratti.net/Imagens/1.jpg')");
            
            migrationBuilder.Sql("Insert Into categoria (Nome, ImagemUrl) " +
                "VALUES ('Lanches', 'http://www.macoratti.net/Imagens/2.jpg')");
           
            migrationBuilder.Sql("Insert Into categoria (Nome, ImagemUrl) " +
                "VALUES ('Sobremesas', 'http://www.macoratti.net/Imagens/3.jpg')");
           
            migrationBuilder.Sql("Insert into produtos(Nome, Descricao, Preco, ImagemUrl,Estoque, DataCadastro, CategoriaId) " +
                "VALUES ('Coca-Cola Diet', 'Refrigerante de cola 350 ml','5.45','http://www.macoratti.net/Imagens/coca.jpg', 50, now(), (SELECT CategoriaId from categoria where Nome='Bebidas'))");
            
            migrationBuilder.Sql("Insert into produtos(Nome, Descricao, Preco, ImagemUrl,Estoque, DataCadastro, CategoriaId) " +
        "VALUES ('Lanche de Atum', 'Lanche de Atum com maionese','8.50', 'http://www.macoratti.net/Imagens/atum.jpg', 10, now(), (SELECT CategoriaId from categoria where Nome='Lanches'))");
            
            migrationBuilder.Sql("Insert into produtos(Nome, Descricao, Preco, ImagemUrl,Estoque, DataCadastro, CategoriaId) " +
        "VALUES ('Pudim 100 g', 'Pudim de leite condensado 100g','6.75', 'http://www.macoratti.net/Imagens/pudim.jpg', 20, now(), (SELECT CategoriaId from categoria where Nome='Sobremesas'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM categoria");
            migrationBuilder.Sql("DELETE FROM produtos");
        }
    }
}
