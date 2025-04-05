INSERT INTO [Role]([Name]) values
('Manager'),
('Staff'),
('Customer');

INSERT INTO TypeOfSkin([Name]) values
(N'None'),
(N'Normal Skin'),
(N'Oily Skin'),
(N'Dry Skin'),
(N'Sensitive Skin');

INSERT INTO [User](Username, [Password], Fullname, Gender, Budget, IsActive, DateCreated, RoleId, TypeOfSkinId) values
('admin@gmail.com', '@123', N'Nguyen Phi Nhan', N'Male', 999999999.99, 1, '20250101', 1, 1),
('staff@gmail.com', '@123', N'Tran Phi Mai', N'Female', 999999999.99, 1, '20250101', 2, 1),
('customer1@gmail.com', '@123', N'Pham Nhat Anh', N'Female', 999999999.99, 1, '20250201', 3, 2),
('customer2@gmail.com', '@123', N'Lu Tu Kiet', N'Male', 999999999.99, 0, '20250301', 3, 1),
('customer3@gmail.com', '@123', N'Tran Khac Trung', N'Male', 999999999.99, 1, '20241218', 3, 1);

INSERT INTO Brand([Name], IsAvailable, Username) values
('Cocoon', 1, 'admin@gmail.com'),
('LOreal', 1, 'admin@gmail.com'),
('3CE', 1, 'staff@gmail.com');

INSERT INTO Category([Name], IsAvailable, Username) values
(N'Facial Cleanser', 1, 'staff@gmail.com'),
(N'Face Mask', 1, 'staff@gmail.com'),
(N'Micellar Water', 1, 'staff@gmail.com'),
(N'Lipstick', 1, 'staff@gmail.com');

INSERT INTO SkincareProduct([Name], [Description], Capacity, UnitPrice, Quantity, [Image], IsAvailable, CategoryId, BrandId, Username) values
(N'Micellar Water 3-in-1', N'LOreal Deep Cleansing Micellar Water 400ml', '400ml', 152000, 10, 'vn-11134201-7ras8-m0mekgjunu252f.jpg', 1, 3, 2, 'staff@gmail.com'),
(N'Winter Melon Micellar Water', N'Cocoon Winter Melon Micellar Water 500ml', '500ml', 140000, 9, 'z5322301407365_da64ee4ef34e8f8c85194a8b3967f354_db4782bf9d.jpg', 1, 3, 1, 'staff@gmail.com'),
(N'3CE Laydown Matte Lip Tint', N'3CE Laydown Matte Lip Tint - Peachy Brown 4.6g Blur Water Tint', '4.6g', 277000, 10, '3624018493198550203900453350152075913799873n-5954.png', 1, 4, 3, 'staff@gmail.com'),
(N'3CE Velvet Lip Tint Daffodil', N'3CE Velvet Lip Tint Daffodil - Earthy Red 4g', '4g', 277000, 7, '02-31-15-21-02-2023-3ce-daf-1.jpg', 1, 4, 3, 'staff@gmail.com'),
(N'LOreal Hydrating Micellar Water', N'LOreal Revitalift Hyaluronic Acid Hydrating Micellar Water 400ml', '400ml', 165000, 10, 'vn-11134207-7qukw-ljnj14p5hcead8.jpg', 1, 3, 2, 'staff@gmail.com');

INSERT INTO Question(Title, Answer, [Type]) values
(N'When you wake up in the morning, how does your skin feel?', 
N'A. Normal, no difference from before sleeping-B. Oily, especially around nose and forehead-C. Dry and flaky-D. Red and peeling', 
'Skin'),
(N'Wash your face with cleanser and warm water. After 20-30 minutes, how does your skin feel?', 
N'A. Good-B. Still oily-C. Dry and rough-D. Red and irritated', 
'Skin'),
(N'Look closely at your pores. How do they appear?', 
N'A. Small-B. Large-C. Dry-D. Red', 
'Skin'),
(N'Which word best describes your skin texture?', 
N'A. Smooth-B. Oily-C. Slightly dry-D. Thin, visible veins', 
'Skin'),
(N'Around noon, how is your skin condition? (Without touching, observe in the mirror)', 
N'A. Same as morning-B. Shiny-C. Dry-D. Sensitive', 
'Skin'),
(N'Do you often squeeze pimples?', 
N'A. Occasionally-B. Frequently, especially during periods-C. Never-D. Only when wearing makeup', 
'Skin'),
(N'How to prevent premature skin aging?', 
N'Use sunscreen daily to protect against UV damage.-Use anti-aging products like vitamin C, retinol, or peptide serums to boost collagen and skin regeneration.', 
'Common'),
(N'Should men care about sensitive skin?', 
N'Sensitive skin can happen to both men and women, so men should also take care of it.', 
'Common'),
(N'What skincare products are suitable for sensitive skin?', 
N'Silicone-based products are usually less irritating.-Use powders with minimal preservatives to reduce the risk of irritation.', 
'Common');

INSERT INTO [Order](DateCreated, Username) values
('20250316', 'customer1@gmail.com');

INSERT INTO OrderDetails(OrderId, SkincareProductId, Quantity, TotalPrice) values
(1, 2, 1, 1 * 140000),
(1, 4, 3, 3 * 277000);