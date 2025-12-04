create table categories
(
    id   serial primary key,
    name varchar not null
);

create table users
(
    id         serial primary key,
    first_name varchar        not null,
    last_name  varchar        not null,
    email      varchar unique not null,
    phone      varchar        not null
);

create table books
(
    id              serial primary key,
    name            varchar   not null,
    author          varchar   not null,
    ref_img         varchar   not null,
    year_of_release int not null,
    description     varchar,
    created_at      timestamp not null default current_timestamp,
    category_id     int       not null references categories (id) on delete cascade
);

create table borrowed_books
(
    id            serial primary key,
    user_id       int not null references users (id) on delete cascade,
    book_id       int not null references books (id) on delete cascade,
    date_taken    timestamp default current_timestamp,
    date_returned timestamp
);
