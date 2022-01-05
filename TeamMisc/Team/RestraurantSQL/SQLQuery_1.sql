
--1.) <>_________________________ QUESTION ONE _________________________<>
-- the 2 reviews with highest rating of a restaurant 
--that contains the word "salt" with following columns, 
--Restaurant Name, Rating, Note

--Solution: 
SELECT TOP 2 Rating, Name, Note --TOP 2
FROM Review 
JOIN Restaurant ON Review.RestaurantId = Restaurant.Id
WHERE RestaurantId LIKE (SELECT Id From Restaurant 
WHERE Name LIKE '%Salt%')
ORDER BY Rating DESC;

--2.) <>_________________________ QUESTION TWO _________________________<>
-- Average rating of each restaurant with following columns, 
--Restaurant Name, Average Rating and list them by 
--their restaurant name in descending order

--Solution: 
SELECT Name, AVG(Rating) as 'AVG Rating', RestaurantId
FROM Restaurant 
LEFT JOIN Review ON Restaurant.Id = Review.RestaurantId
GROUP BY Name, RestaurantId
ORDER BY Name DESC;

--3.) <>_________________________ QUESTION THREE _________________________<>
-- The number of reviews from each restaurant that has rating 4 or higher

--Solution
SELECT Name, COUNT(REVIEW.Id) as 'NumReviews' 
FROM Review 
JOIN Restaurant ON Restaurant.Id = Review.RestaurantId
WHERE Rating >= 4 
GROUP BY Name;