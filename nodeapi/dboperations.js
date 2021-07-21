var config = require('./dbconfig');
const sql = require('mssql');


async function getMovies(){
    try{
        let pool = await sql.connect(config);
        let movies = await pool.request().query("select * from tbl_Movies");
        return movies.recordsets;
    }
    catch (error){
        console.log(error);
    }
}

module.exports = {
    getMovies:getMovies
}