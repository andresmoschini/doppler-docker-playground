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
                sh '''docker build \\
                    --target build \\
                    -t "fromdoppler/doppler-docker-playground:production-commit-${GIT_COMMIT}" \\
                    --build-arg version=production-commit-${GIT_COMMIT} \\
                    .'''
            }
        }
        stage('Test') {
            steps {
                sh 'docker build --target test .'
            }
        }
        stage('Publish pre release version images') {
            steps {
                // It is a temporal step, in the future we will only publish final version images
                sh 'sh ./publish-commit-image-to-dockerhub.sh production ${GIT_COMMIT} v0.0.0 commit-${GIT_COMMIT}'
            }
        }
    }
}
