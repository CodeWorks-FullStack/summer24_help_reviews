CREATE TABLE
  IF NOT EXISTS accounts (
    id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    name varchar(255) COMMENT 'User Name',
    email varchar(255) UNIQUE COMMENT 'User Email',
    picture varchar(255) COMMENT 'User Picture'
  ) default charset utf8mb4 COMMENT '';

CREATE TABLE
  restaurants (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    name VARCHAR(255) NOT NULL,
    imgUrl VARCHAR(3000) NOT NULL,
    description VARCHAR(1000) NOT NULL,
    isShutdown BOOLEAN NOT NULL,
    visits INT NOT NULL DEFAULT 0,
    creatorId VARCHAR(255) NOT NULL,
    FOREIGN KEY (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
  );

SELECT
  *
FROM
  accounts;

INSERT INTO
  restaurants (name, imgUrl, description, isShutdown, creatorId)
VALUES
  (
    "Tuna Tuba",
    "https://images.unsplash.com/photo-1565123409695-7b5ef63a2efb?q=80&w=2342&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
    "In tuna we trust, in tubas we gust",
    true,
    "66bb8ddd637da0ef8d71e1e7"
  );

SELECT
  *
FROM
  restaurants;