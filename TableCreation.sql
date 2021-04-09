-- SQLite
DROP TABLE `Products`;
CREATE TABLE `Products`(
   Id INTEGER PRIMARY KEY AUTOINCREMENT,
   Name TEXT,
   Created TEXT,
   Price REAL
);

DROP TABLE `PriceHistories`;
CREATE TABLE `PriceHistories`(
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    ProductId INT,
    Date TEXT,
    -- OldPrice REAL,
    NewPrice REAL
);