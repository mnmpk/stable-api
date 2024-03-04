const { MongoClient } = require("mongodb");

const uri = "mongodb+srv://admin:admin@demo.uskpz.mongodb.net/test?retryWrites=true&w=majority";

const client = new MongoClient(uri,
  //{ serverApi: { version: '1' } }

  //APIStrictError
  //{ serverApi: { version: '1', strict: true } }

  //APIDeprecationError
  //{ serverApi: { version: '1', strict: true, deprecationErrors: true } }

  //APIVersionError
  //{ serverApi: { version: '99' } }

  //InvalidOptions
  //{ serverApi: { strict: true, deprecationErrors: true } }
);


async function run() {
  try {
    //const database = client.db('sample_mflix');
    //const movies = database.collection('movies');

    // Query for a movie that has the title 'Back to the Future'
    //const query = { title: 'Back to the Future' };
    //const movie = await movies.findOne(query);
    //console.log(movie);


    //const aggCursor = movies.aggregate([
    //  {
    //    '$match': query
    //  }, {
    //    '$lookup': {
    //      'from': 'comments', 
    //      'localField': '_id', 
    //      'foreignField': 'movie_id', 
    //      'as': 'comments'
    //    }
    //  }
    //]);
    // Print the aggregated results
    //for await (const doc of aggCursor) {
    //    console.log(doc);
    //}


    const adminDB = client.db('admin');
    console.log(await adminDB.command({ "replSetGetStatus": 1 }));
  } finally {
    // Ensures that the client will close when you finish/error
    await client.close();
  }
}
run();