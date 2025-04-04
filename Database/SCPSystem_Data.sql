INSERT INTO [Role]([Name]) values
('Manager'),
('Staff'),
('Customer');

INSERT INTO TypeOfSkin([Name]) values
(N'None'),
(N'Da thường'),
(N'Da dầu'),
(N'Da khô'),
(N'Da nhạy cảm');

INSERT INTO [User](Username, [Password], Fullname, Gender, Budget, IsActive, DateCreated, RoleId, TypeOfSkinId) values
('admin@gmail.com', '@123', N'Nguyễn Phi Nhạn', N'Nam', 999999999.99, 1, '20250101', 1, 1),
('staff@gmail.com', '@123', N'Trần Phi Mai', N'Nữ', 999999999.99, 1, '20250101', 2, 1),
('customer1@gmail.com', '@123', N'Phạm Nhật Ánh', N'Nữ', 999999999.99, 1, '20250201', 3, 2),
('customer2@gmail.com', '@123', N'Lu Tử Kiệt', N'Nam', 999999999.99, 0, '20250301', 3, 1),
('customer3@gmail.com', '@123', N'Trần Khắc Trung', N'Nam', 999999999.99, 1, '20241218', 3, 1);

INSERT INTO Brand([Name], IsAvailable, Username) values
('Cocoon', 1, 'admin@gmail.com'),
('LOreal', 1, 'admin@gmail.com'),
('3CE', 1, 'staff@gmail.com');

INSERT INTO Category([Name], IsAvailable, Username) values
(N'Sữa rửa mặt', 1, 'staff@gmail.com'),
(N'Mặt nạ', 1, 'staff@gmail.com'),
(N'Nước tẩy trang', 1, 'staff@gmail.com'),
(N'Son môi', 1, 'staff@gmail.com');

INSERT INTO SkincareProduct([Name], [Description], Capacity, UnitPrice, Quantity, [Image], IsAvailable, CategoryId, BrandId, Username) values
(N'Micellar Water 3-in-1', N'Nước Tẩy Trang LOreal Làm Sạch Sâu Trang Điểm 400ml', '400ml', 152000, 10, 'vn-11134201-7ras8-m0mekgjunu252f.jpg', 1, 3, 2, 'staff@gmail.com'),
(N'Nước Tẩy Trang Bí Đao', N'Cocoon Nước Tẩy Trang Bí Đao 500ml', '500ml', 140000, 9, 'z5322301407365_da64ee4ef34e8f8c85194a8b3967f354_db4782bf9d.jpg', 1, 3, 1, 'staff@gmail.com'),
(N'Son Kem Lì 3CE Laydown', N'Son Kem Lì 3CE Laydown - Hồng Đào Trầm Pha Nâu 4.6g Blur Water Tint', '4.6g', 277000, 10, '3624018493198550203900453350152075913799873n-5954.png', 1, 4, 3, 'staff@gmail.com'),
(N'Son Kem Lì 3CE Mịn Như Nhung Daffodil', N'Son Kem Lì 3CE Mịn Như Nhung Daffodil - Đỏ Đất 4g Velvet Lip Tint', '4g', 277000, 7, '02-31-15-21-02-2023-3ce-daf-1.jpg', 1, 4, 3, 'staff@gmail.com'),
(N'Nước Tẩy Trang LOreal Căng Mịn Da', N'Nước Tẩy Trang LOreal Căng Mịn Da 400ml - Revitalift Hyaluronic Acid Hydrating Micellar Water', '400ml', 165000, 10, 'vn-11134207-7qukw-ljnj14p5hcead8.jpg', 1, 3, 2, 'staff@gmail.com');

INSERT INTO Question(Title, Answer, [Type]) values
(N'Vào mỗi buổi sáng thức dậy, bạn thấy da mình như thế nào?', 
N'A. Bình thường, không có sự khác biệt so với trước khi ngủ-B. Nhiều dầu, tập trung ở mũi và trán-C. Khô và nẻ-D. Tấy đỏ, bong da', 
'Skin'),
(N'Thực hiện rửa mặt với sữa rửa mặt của bạn với nước ấm. Từ 20 đến 30p sau, cảm nhận của da bạn là thế nào?', 
N'A. Tốt-B. Vẫn còn nhiều dầu-C. Khô và ráp-D. Mẫn đỏ', 
'Skin'),
(N'Hãy nhìn kỹ xem lỗ chân lông trên da bạn ra sao?', 
N'A. Nhỏ-B. Lớn-C. Khô-D. Đỏ', 
'Skin'),
(N'Từ nào dưới đây có thể miêu tả kết cấu da bạn?', 
N'A. Mềm mịn-B. Nhiều dầu-C. Hơi khô-D. Mỏng, lộ đường mạch máu', 
'Skin'),
(N'Vào buổi trưa, da bạn ở tình trạng nào? (Không dùng tay, chỉ soi gương để đoán)', 
N'A. Như buổi sáng-B. Sáng-C. Khô-D. Nhạy cảm', 
'Skin'),
(N'Bạn có thường xuyên nặn mụn trứng cá?', 
N'A. Thỉnh thoảng-B. Thường xuyên, đặc biệt vào chu kỳ-C. Không bao giờ-D. Chỉ khi trang điểm', 
'Skin'),
(N'Làm thế nào để phòng ngừa tình trạng lão hóa da sớm?', 
N'Dùng kem chống nắng mỗi ngày để bảo vệ da trước tác hại của tia UV.-Chăm sóc da bằng các sản phẩm chống lão hóa như serum chứa vitamin C, retinol hoặc peptide để tăng cường sản xuất collagen và tái tạo da.', 
'Common'),
(N'Nam giới có nên quan tâm về da nhạy cảm?', 
N'Da nhạy cảm có thể xảy ra ở cả nữ và nam, để bảo vệ da, nam giới cũng cần quan tâm đến vấn đề da nhạy cảm.', 
'Common'),
(N'Da nhạy cảm dùng mỹ phẩm gì?', 
N'Những sản phẩm dưỡng da chứa silicone thường ít gây kích ứng da.-Sử dụng các loại phấn phủ có ít chất bảo quản, đây là sản phẩm có nguy cơ kích ứng da rất thấp.', 
'Common');

INSERT INTO [Order](DateCreated, Username) values
('20250316', 'customer1@gmail.com');

INSERT INTO OrderDetails(OrderId, SkincareProductId, Quantity, TotalPrice) values
(1, 2, 1, 1 * 140000),
(1, 4, 3, 3 * 277000);