DROP DATABASE IF EXISTS `orders`;
CREATE DATABASE `orders` CHARACTER SET utf8 COLLATE utf8_unicode_ci;

USE `orders`;

DROP TABLE IF EXISTS `products`; CREATE TABLE `products` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `price` decimal(10,2) NOT NULL,
  PRIMARY KEY (`id`)
);

DROP TABLE IF EXISTS `customers`; CREATE TABLE `customers` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
);

DROP TABLE IF EXISTS `orders`; CREATE TABLE `orders` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `date` datetime NOT NULL,
  PRIMARY KEY (`id`)
);

DROP TABLE IF EXISTS `order_items`;CREATE TABLE `order_items` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `order_id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL,
  `quantity` decimal(10,2) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_order_items_orders_idx` (`order_id`),
  KEY `fk_order_items_products_idx` (`product_id`),
  CONSTRAINT `fk_order_items_orders` FOREIGN KEY (`order_id`) REFERENCES `orders` (`id`) ON DELETE NO ACTION ON
UPDATE NO ACTION,
  CONSTRAINT `fk_order_items_products` FOREIGN KEY (`product_id`) REFERENCES `products` (`id`) ON
DELETE NO ACTION ON
UPDATE NO ACTION
);

INSERT INTO `products` VALUES (1,'beer',1.20), (2,'cheese',9.50), (3,'rakiya',12.40), (4,'salami',6.33), (5,'tomatos',2.50), (6,'cucumbers',1.35), (7,'water',0.85), (8,'apples',0.75); INSERT INTO `customers` VALUES (1,'Peter'), (2,'Maria'), (3,'Nakov'), (4,'Vlado');
INSERT INTO `orders` VALUES (1,'2015-02-13 13:47:04'), (2,'2015-02-14 22:03:44'), (3,'2015-02-18 09:22:01'), (4,'2015-02-11 20:17:18');
INSERT INTO `order_items` VALUES (12,4,6,2.00), (13,3,2,4.00), (14,3,5,1.50), (15,2,1,6.00), (16,2,3,1.20), (17,1,2,1.00), (18,1,3,1.00), (19,1,4,2.00), (20,1,5,1.00), (21,3,1,4.00), (22,1,1,3.00);

 
SELECT p.name AS product_name, 
       COUNT(oi.product_id) AS num_orders,
       IFNULL(SUM(oi.quantity), 0) AS quantity,
       p.price,
	   IFNULL(SUM(oi.quantity) * p.price, 0) AS total_price
	FROM products p
    LEFT JOIN order_items oi
    ON p.id = oi.product_id
    LEFT JOIN orders o
	ON oi.order_id = o.id
GROUP BY p.id, p.name, p.price
ORDER BY p.name
    





