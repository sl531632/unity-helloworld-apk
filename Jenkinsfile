pipeline {
    agent {
        docker {
            image 'unityci/editor:ubuntu-2021.3.1f1-android-1.0.1'
            args '-u root:root --rm  -v /root/jenkins/lic/:/root/.local/share/unity3d/Unity/  -v /root/jenkins/workspace/unity-demo:/build/unity-demo --privileged'
        }
    }
    stages {
        stage('Build') {
				steps {
					// 编译 Unity 项目
					sh 'xvfb-run --auto-servernum --server-args="-screen 0 640x480x24" unity-editor -projectPath /build/unity-demo -executeMethod BuildScript.BuildAndroid -batchmode -quit -logFile /build/unity-demo/unity-build.log -nographics'
				}
        }
        stage('Archive') {
            steps {
                archiveArtifacts artifacts: '/build/unity-demo/*.apk', fingerprint: true
            }
        }
    }
}

