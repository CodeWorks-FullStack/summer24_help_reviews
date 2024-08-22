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
    visits INT UNSIGNED NOT NULL DEFAULT 0,
    creatorId VARCHAR(255) NOT NULL,
    FOREIGN KEY (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
  );

CREATE TABLE
  reports (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    title VARCHAR(255) NOT NULL,
    body TEXT NOT NULL,
    pictureOfDisgust VARCHAR(3000),
    restaurantId INT NOT NULL,
    creatorId VARCHAR(255) NOT NULL,
    FOREIGN KEY (restaurantId) REFERENCES restaurants (id) ON DELETE CASCADE,
    FOREIGN KEY (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
  );

ALTER TABLE restaurants MODIFY COLUMN visits INT UNSIGNED NOT NULL DEFAULT 0;

SELECT
  *
FROM
  accounts;

INSERT INTO
  restaurants (name, imgUrl, description, isShutdown, creatorId)
VALUES
  (
    "Spaghetti Spencers",
    "https://plus.unsplash.com/premium_photo-1664391765043-57f702c4d41d?q=80&w=2264&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
    "Itsa ketchup",
    false,
    "66bb8385904c176f444e8947"
  );

SELECT
  r.*,
  a.*
FROM
  restaurants r
  JOIN accounts a;