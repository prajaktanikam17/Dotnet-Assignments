-- Use existing database
USE medicalstoredb;

-- Drop old tables (safe reset)
DROP TABLE IF EXISTS BillDetails;
DROP TABLE IF EXISTS Bill;
DROP TABLE IF EXISTS Medicine;
DROP TABLE IF EXISTS Customer;
DROP TABLE IF EXISTS Sales;

-- Customer Table
CREATE TABLE Customer (
    CustomerId INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(50) NOT NULL
);

-- Medicine Table
CREATE TABLE Medicine (
    MedicineId INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(50),
    Rate INT
);

-- Bill Table
CREATE TABLE Bill (
    BillId INT AUTO_INCREMENT PRIMARY KEY,
    CustomerId INT,
    BillDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (CustomerId) REFERENCES Customer(CustomerId)
);

-- BillDetails Table
CREATE TABLE BillDetails (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    BillId INT,
    MedicineId INT,
    Quantity INT,
    FOREIGN KEY (BillId) REFERENCES Bill(BillId),
    FOREIGN KEY (MedicineId) REFERENCES Medicine(MedicineId)
);

-- Sales Table (Report)
CREATE TABLE Sales (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    CustomerName VARCHAR(50),
    MedicineName VARCHAR(50),
    Quantity INT,
    Rate INT,
    Total INT,
    BillDate DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- Sample Data
INSERT INTO Customer(Name) VALUES ('Prajakta');

INSERT INTO Medicine(Name, Rate) VALUES 
('Crocin', 10),
('Dolo 650', 15);

INSERT INTO Sales(CustomerName, MedicineName, Quantity, Rate, Total)
VALUES 
('Prajakta', 'Crocin', 2, 10, 20),
('Prajakta', 'Dolo 650', 1, 15, 15);