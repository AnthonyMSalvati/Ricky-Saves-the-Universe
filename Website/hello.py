from datetime import datetime
from flask import Flask, request, flash, url_for, redirect, \
    render_template, abort
from flask_sqlalchemy import SQLAlchemy
import sqlalchemy.orm
from cockroachdb.sqlalchemy import run_transaction
from sqlalchemy import func
from sqlalchemy import create_engine

app = Flask(__name__)
app.config.from_pyfile('.env')
db = SQLAlchemy(app)
sessionmaker = sqlalchemy.orm.sessionmaker(db.engine)


class Scores1(db.Model):
    __tablename__ = 'scores1'
    id = db.Column('id', db.Integer, primary_key=True)
    name = db.Column(db.String(60))
    h_score = db.Column(db.Integer)

    def __init__(self, name, h_score):
        self.name = name
        self.h_score = h_score


def show_all():
		scores = db.session.query(func.max(Scores1.h_score)).all()
		print("highest score of the day")
		print(scores)


show_all()


@app.route('/')
def show_all_on():
    def callback(session):
        return render_template(
            'show_all.html',
            scores=db.session.query(func.max(Scores1.h_score)).all())
    return run_transaction(sessionmaker, callback)

if __name__ == '__main__':
    app.run()
