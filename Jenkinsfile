pipeline {
    agent {
        docker {
            image 'unityci/editor:ubuntu-2022.2.12f1-windows-mono-1.0.1'
            args '-u root:root -v /tmp/.X11-unix:/tmp/.X11-unix:rw --privileged'
        }
    }
    stages {
        stage('Build') {
				steps {
					// 设置 Unity 许可证
					//sh 'curl -L https://raw.githubusercontent.com/game-ci/docker/develop/scripts/unity-accelerator.sh -o unity-accelerator.sh'
					//sh 'chmod +x unity-accelerator.sh'
					//sh './unity-accelerator.sh'
					//sh 'export UNITY_LICENSE="$(cat /path/to/your/unity_license_file.ulf)"'
					//sh 'echo "$UNITY_LICENSE" | base64 --decode | gzip > /root/.local/share/unity3d/Unity/Unity_lic.ulf'

					// 编译 Unity 项目
					sh 'xvfb-run --auto-servernum --server-args="-screen 0 640x480x24" unity-editor -projectPath /var/jenkins_home/workspace/unity-demo -executeMethod BuildScript.BuildAndroid -batchmode -quit -logFile /dev/stdout -nographics'
				}
        }
        stage('Archive') {
            steps {
                archiveArtifacts artifacts: 'output/build/**/*', fingerprint: true
            }
        }
    }
}



