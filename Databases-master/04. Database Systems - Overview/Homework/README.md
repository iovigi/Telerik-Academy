## Database Systems - Overview
### _Homework_

####1.  What database models do you know?
Hierarchical model
Network model
Relational Model
Object-oriented Model
Object-relational Model
####1.  Which are the main functions performed by a Relational Database Management System (RDBMS)?
    Relational Database Management Systems (RDBMS) manage data stored in tables
    RDBMS systems typically implement
        Creating / altering / deleting tables and relationships between them (database schema)
        Adding, changing, deleting, searching and retrieving of data stored in the tables
        Support for the SQL language
        Transaction management (optional)
####1.  Define what is "table" in database terms.
In database terms, a table is responsible for storing data in the database. Database tables consist of rows and columns.
####1.  Explain the difference between a primary and a foreign key.
Primary key is unique index in table, which is used for unique describe some record. With foreign key is make relation between two table.  
####1.  Explain the different kinds of relationships between tables in relational databases.
    One-to-one: Both tables can have only one record on either side of the relationship. 
    One-to-many: The primary key table contains only one record that relates to none, one, or many records in the related table. 
    Many-to-many: Each record in both tables can relate to any number of records (or no records) in the other table. 
####1.  When is a certain database schema normalized?
The goal of data normalization is to reduce and even eliminate data redundancy, an important consideration for application developers because it is incredibly difficult to stores objects in a relational database that maintains the same information in several places.
  * What are the advantages of normalized databases?
  The advantage of having a highly normalized data schema is that information is stored in one place and one place only, reducing the possibility of inconsistent data.
####1.  What are database integrity constraints and when are they used?
Integrity constraints provide a mechanism for ensuring that data conforms to guidelines.
The most common types of constraints include:
    UNIQUE constraints
    To ensure that a given column is unique
    NOT NULL constraints
    To ensure that no null values are allowed
    FOREIGN KEY constraints
    To ensure that two keys share a primary key to foreign key relationship
####1.  Point out the pros and cons of using indexes in a database.
 Use an index for quick access to a database table specific information.
 Too index will affect the speed of update and insert, because it requires the same update each index file.
####1.  What's the main purpose of the SQL language?
SQL is used to communicate with a database. It is the standard language for relational database management systems.
####1.  What are transactions used for?
A transaction, in the context of a database, is a logical unit that is independently executed for data retrieval or updates. 
  * Give an example.
  A classical example is transferring money from one bank account to another.
####1.  What is a NoSQL database?
A NoSQL database environment is, simply put, a non-relational and largely distributed database system that enables rapid, ad-hoc organization and analysis of extremely high-volume, disparate data types.
####1.  Explain the classical non-relational data models.
Column
Document
Key-value
Graph
Multi-model
####1.  Give few examples of NoSQL databases and their pros and cons.
STSdb, it is fastest possible index algorithm, use model key-value store. Solve problems with big data and problems related with operating with this data real time.

 
