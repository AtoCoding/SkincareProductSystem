INSERT INTO [Role]([Name]) values
('Manager'),
('Staff'),
('Customer');

INSERT INTO [User](Username, [Password], Fullname, Gender, IsActive, RoleId) values
('admin@gmail.com', '@123', N'Nguyễn Phi Nhạn', N'Nam', 1, 1),
('staff@gmail.com', '@123', N'Trần Phi Mai', N'Nữ', 1, 2),
('customer1@gmail.com', '@123', N'Phạm Nhật Ánh', N'Nữ', 1, 3),
('customer2@gmail.com', '@123', N'Lu Tử Kiệt', N'Nam', 0, 3),
('customer3@gmail.com', '@123', N'Trần Khắc Trung', N'Nam', 1, 3);

INSERT INTO Brand([Name], IsAvailable, Username) values
('Cocoon', 1, 'admin@gmail.com'),
('LOreal', 1, 'admin@gmail.com'),
('3CE', 1, 'staff@gmail.com');

INSERT INTO Category([Name], Quantity, IsAvailable, Username) values
(N'Sữa rửa mặt', 0, 1, 'staff@gmail.com'),
(N'Mặt nạ', 0, 1, 'staff@gmail.com'),
(N'Nước tẩy trang', 3, 1, 'staff@gmail.com'),
(N'Son môi', 2, 1, 'staff@gmail.com');

INSERT INTO SkincareProduct([Name], [Description], Capacity, UnitPrice, IsAvailable, CategoryId, BrandId, Username) values
(N'Micellar Water 3-in-1', N'Nước Tẩy Trang LOreal Làm Sạch Sâu Trang Điểm 400ml', '400ml', 152000, 1, 3, 2, 'staff@gmail.com'),
(N'Nước Tẩy Trang Bí Đao', N'Cocoon Nước Tẩy Trang Bí Đao 500ml', '500ml', 140000, 1, 3, 1, 'staff@gmail.com'),
(N'Son Kem Lì 3CE Laydown', N'Son Kem Lì 3CE Laydown - Hồng Đào Trầm Pha Nâu 4.6g Blur Water Tint', '4.6g', 277000, 1, 4, 3, 'staff@gmail.com'),
(N'Son Kem Lì 3CE Mịn Như Nhung Daffodil', N'Son Kem Lì 3CE Mịn Như Nhung Daffodil - Đỏ Đất 4g Velvet Lip Tint', '4g', 277000, 1, 4, 3, 'staff@gmail.com'),
(N'Nước Tẩy Trang LOreal Căng Mịn Da', N'Nước Tẩy Trang LOreal Căng Mịn Da 400ml - Revitalift Hyaluronic Acid Hydrating Micellar Water', '400ml', 165000, 1, 3, 2, 'staff@gmail.com');