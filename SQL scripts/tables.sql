create table country
(
    id   int identity
        constraint country_pk
            primary key nonclustered,
    name varchar(50) not null
)
go

create table school
(
    name       varchar(50) not null,
    id_country int         not null
        constraint school_country_id_fk
            references country
            on delete cascade,
    id         int identity
        constraint school_pk
            primary key nonclustered
)
go

create table student
(
    identity_card int identity
        constraint student_pk
            primary key nonclustered,
    names         varchar(100) not null,
    surnames      varchar(100),
    date_of_birth date,
    id_school     int          not null
        constraint student_school_id_fk
            references school
            on delete cascade
)
go


