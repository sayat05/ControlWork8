create table books(
                      id serial primary key not null,
                      name varchar not null,
                      author varchar not null,
                      ref_img varchar not null,
                      create_date timestamp,
                      description text,
                      date_added timestamp not null default current_timestamp,
                      category_id integer not null,

                      foreign key (category_id) references categories(id)
);

create table statuses_books(
                               id serial primary key not null,
                               book_id integer not null,
                               status integer not null,

                               foreign key (book_id) references books (id)
);

create table users(
                      id serial primary key not null,
                      name varchar not null,
                      lastname varchar not null,
                      email varchar not null,
                      phone_number varchar
);

create table library_users(
                              id serial primary key not null,
                              user_id integer not null,
                              date_added timestamp not null default current_timestamp,

                              foreign key (user_id) references users (id)
);

create table books_issued(
                             id serial primary key  not null,
                             user_id integer not null,
                             book_id integer not null,
                             issued_date timestamp not null default current_timestamp,
                             return_date timestamp,

                             foreign key (user_id) references users (id),
                             foreign key (book_id) references books (id)
);

create table categories (
                            id serial primary key not null,
                            name varchar not null
)

