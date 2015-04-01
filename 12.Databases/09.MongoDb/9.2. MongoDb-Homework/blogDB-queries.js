use blog

// get all posts(title, category and tags)
db.posts.aggregate([{
    $project: {
        _id: 0,
        "author.name": 1,
        title: 1,
        tags: 1
    }
}]);

// get all posts from category database
db.posts.find({
    category: {
        $eq: "Databases"
    }
}, {
    _id: 0,
    title: 1,
    "author.twitter": 1,
});

// get all posts from 2011
db.posts.find({
    date: {
        "$gte": ISODate("2011-01-01T00:00:00Z"),
        "$lt": ISODate("2012-01-01T00:00:00Z")
    }
}, {
    _id: 0,
    title: 1,
    "author.linkedIn": 1,
});

// update  minka's tag Bentley to Bentley GT
db.posts.update({
    "author.name": {
        $eq: "Minka Mazgaldjieva"
    },
    tags: {
        $eq: "Bentley"
    }
}, {
    $set: {
        "tags.$": "Bentley GT"
    }
});


// group by category and get count for each
db.posts.aggregate([{
    $group: {
        _id: "$category",
        posts: {
            $sum: 1
        }
    }
}]);