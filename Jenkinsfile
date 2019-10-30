pipeline {
    agent any
    stages {
        stage('Restore') {
            steps {
                sh 'docker build --target restore .'
            }
        }
        stage('Build') {
            steps {
                sh 'docker build --target build .'
            }
        }
        stage('Test') {
            steps {
                sh 'docker build --target test .'
            }
        }
        stage('Deploy build image') {
            steps {
                sh 'sh ./publish-to-dockerhub.sh build-$BUILD_NUMBER'
            }
        }
        stage('Deploy for development') {
            when {
                branch 'development'
            }
            steps {
                echo 'TODO: Deploy to development'
            }
        }
        stage('Deploy for production') {
            when {
                branch 'master'
            }
            steps {
                sh 'sh ./publish-to-dockerhub.sh beta'
            }
        }
    }
}
