USE [Aranda.TestBackend.DataBase]

INSERT INTO [dbo].[Category] ([Name])
VALUES 
    ('Electrónica'),
    ('Ropa'),
    ('Alimentos'),
    ('Muebles'),
    ('Libros');

INSERT INTO [dbo].[Product] ([NameProduct], [Description], [CategoryId], [ImageUrl])
VALUES 
    ('Smartphone', 'Teléfono inteligente de última generación', 1, 'http://example.com/smartphone.jpg'),
    ('Camiseta', 'Camiseta de algodón, talla M', 2, 'http://example.com/camiseta.jpg'),
    ('Pan Integral', 'Pan de trigo integral, 500g', 3, 'http://example.com/pan.jpg'),
    ('Silla de oficina', 'Silla ergonómica para oficina', 4, 'http://example.com/silla.jpg'),
    ('El Gran Libro de SQL', 'Guía completa sobre SQL', 5, 'http://example.com/sqlbook.jpg');