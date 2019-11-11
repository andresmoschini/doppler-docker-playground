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
                // TODO, for final versions, ensure having the proper version in version.txt in place of the commit number
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
        stage('Publish final version images') {
            when {
                expression {
                    return isVersionTag(readCurrentTag())
                }
            }
            steps {
                // TODO, ensure having the proper version in version.txt in place of the commit number
                sh 'sh publish-commit-image-to-dockerhub.sh production ${GIT_COMMIT} ${TAG_NAME}'
            }
        }
        stage('Generate version') {
            when {
                branch 'master'
            }
            steps {
                sh 'TODO: generate a tag automatically'
            }
        }
    }
}

def boolean isVersionTag(String tag) {
    echo "checking version tag $tag"

    if (tag == null) {
        return false
    }

    // use your preferred pattern
    def tagMatcher = tag =~ /v\d+\.\d+\.\d+/

    return tagMatcher.matches()
}

// https://stackoverflow.com/questions/56030364/buildingtag-always-returns-false
// workaround https://issues.jenkins-ci.org/browse/JENKINS-55987
def String readCurrentTag() {
    return sh(returnStdout: true, script: "git describe --tags --match v?*.?*.?* --abbrev=0 --exact-match || echo ''").trim()
}
